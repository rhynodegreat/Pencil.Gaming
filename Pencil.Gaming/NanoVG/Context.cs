using System;
using System.Runtime.InteropServices;

using Pencil.Gaming.Graphics;

using static Pencil.Gaming.NanoVG.NanoVG_native;

namespace Pencil.Gaming.NanoVG {
    public class Context {
        internal IntPtr ctx;
        public Context(CreateFlags flags) {
            ctx = nvgCreateContext((int)flags);
        }

        public void BeginFrame(int windowWidth, int windowHeight, float devicePixelRatio) {
            nvgBeginFrame(ctx, windowWidth, windowHeight, devicePixelRatio);
        }

        public void CancelFrame() {
            nvgCancelFrame(ctx);
        }

        public void EndFrame() {
            nvgEndFrame(ctx);
        }

        public void Save() {
            nvgSave(ctx);
        }

        public void Restore() {
            nvgRestore(ctx);
        }

        public void Reset() {
            nvgReset(ctx);
        }

        public void StrokeColor(Color4 color) {
            nvgStrokeColor(ctx, color);
        }

        public void StrokeColor(float r, float g, float b, float a) {
            nvgStrokeColor(ctx, new Color4(r, g, b, a));
        }

        public void StrokePaint(Paint paint) {
            nvgStrokePaint(ctx, new PaintNative(paint));
        }

        public void FillColor(Color4 color) {
            nvgFillColor(ctx, color);
        }

        public void FillColor(float r, float g, float b, float a) {
            nvgFillColor(ctx, new Color4(r, g, b, a));
        }

        public void FillPaint(Paint paint) {
            nvgFillPaint(ctx, new PaintNative(paint));
        }

        public void MiterLimit(float limit) {
            nvgMiterLimit(ctx, limit);
        }

        public void StrokeWidth(float width) {
            nvgStrokeWidth(ctx, width);
        }

        public void LineCap(LineCap lineCap) {
            nvgLineCap(ctx, (int)lineCap);
        }

        public void LineJoin(LineJoin lineJoin) {
            nvgLineJoin(ctx, (int)lineJoin);
        }

        public void GlobalAlpha(float alpha) {
            nvgGlobalAlpha(ctx, alpha);
        }

        public void BeginPath() {
            nvgBeginPath(ctx);
        }

        public void ClosePath() {
            nvgClosePath(ctx);
        }

        public void Rect(float x, float y, float w, float h) {
            nvgRect(ctx, x, y, w, h);
        }

        public void Fill() {
            nvgFill(ctx);
        }

        public void Stroke() {
            nvgStroke(ctx);
        }

        public void FontSize(float size) {
            nvgFontSize(ctx, size);
        }

        public void FontBlur(float blur) {
            nvgFontSize(ctx, blur);
        }

        public void TextLetterSpacing(float spacing) {
            nvgFontSize(ctx, spacing);
        }

        public void TextLineHeight(float height) {
            nvgFontSize(ctx, height);
        }

        public void TextAlign(Align value) {
            nvgTextAlign(ctx, (int)value);
        }

        public void UseFont(Font font) {
            nvgFontFaceId(ctx, font.ID);
        }

        public float Text(float x, float y, string text) {
            return nvgText(ctx, x, y, text, (IntPtr)0);
        }

        public void TextBox(float x, float y, float breakRowWidth, string text) {
            nvgTextBox(ctx, x, y, breakRowWidth, text, (IntPtr)0);
        }
    }
}
