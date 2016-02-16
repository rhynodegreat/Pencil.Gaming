using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pencil.Gaming.Graphics {
    public struct Color32 : IEquatable<Color32> {
        public byte r, g, b, a;

        public Color32(byte r, byte g, byte b, byte a) {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color32(int r, int g, int b, int a) : this((byte)r, (byte)g, (byte)b, (byte)a) { }

        public Color32(float r, float g, float b, float a) : this((byte)r, (byte)g, (byte)b, (byte)a) { }

        public Color32(Color4 color) : this(color.R, color.G, color.B, color.A) { }

        public Color32(int r, int g, int b) : this((byte)r, (byte)g, (byte)b, (byte)255) { }

        public Color32(float r, float g, float b) : this((byte)r, (byte)g, (byte)b, (byte)255) { }

        public bool Equals(Color32 other) {
            return this.r == other.r &&
                this.g == other.g &&
                this.b == other.b &&
                this.a == other.a;
        }

        public override bool Equals(object other) {
            if (other is Color32) {
                return Equals((Color32)other);
            } else {
                return false;
            }
        }

        public override int GetHashCode() {
            return r.GetHashCode() ^
                g.GetHashCode() ^
                b.GetHashCode() ^
                a.GetHashCode();
        }

        public static bool operator == (Color32 a, Color32 b) {
            return a.Equals(b);
        }

        public static bool operator != (Color32 a, Color32 b) {
            return !a.Equals(b);
        }
    }
}
