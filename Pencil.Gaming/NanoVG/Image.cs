using System;
using System.IO;
using System.Runtime.InteropServices;

using static Pencil.Gaming.NanoVG.NanoVG_native;

namespace Pencil.Gaming.NanoVG {
    public class Image : IDisposable {
        public Context Context { get; private set; }
        public int ID { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Image(Context ctx, string filename, ImageFlags flags) {
            ID = nvgCreateImage(ctx.ctx, filename, (int)flags);
            int w, h;
            nvgImageSize(ctx.ctx, ID, out w, out h);
            Width = w;
            Height = h;
            Console.WriteLine("Image Width: {0} Height: {1}", w, h);
        }

        public Image(Context ctx, int w, int h, byte[] data, ImageFlags flags) {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            Init(ctx, w, h, handle.AddrOfPinnedObject(), flags);
            handle.Free();
        }

        void Init(Context ctx, int w, int h, IntPtr data, ImageFlags flags){
            Context = ctx;
            Width = w;
            Height = h;
            ID = nvgCreateImageRGBA(ctx.ctx, w, h, (int)flags, data);
        }

        public void Update(byte[] data) {
            GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
            nvgUpdateImage(Context.ctx, ID, handle.AddrOfPinnedObject());
            handle.Free();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposed) {
            if (disposed) {
                Context = null;
            }
            nvgDeleteImage(Context.ctx, ID);
        }

        ~Image() {
            Dispose(false);
        }
    }
}
