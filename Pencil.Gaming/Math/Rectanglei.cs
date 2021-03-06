using System;
using Pencil.Gaming.Math;

namespace Pencil.Gaming.Math {
	public struct Rectanglei {
		public int X, Y, Width, Height;
		public Vector2i Position {
			get {
				return new Vector2i(X, Y);
			}
			set {
				X = value.X;
				Y = value.Y;
			}
		}
		public Vector2i Size {
			get {
				return new Vector2i(Width, Height);
			}
			set {
				Width = value.X;
				Height = value.Y;
			}
		}

		public int Top {
			get {
				return Y + Height;
			}
			set {
				Y = value - Height;
			}
		}

		public int Bottom {
			get {
				return Y;
			}
			set {
				Y = value;
			}
		}

		public int Right {
			get {
				return X + Width;
			}
			set {
				X = value - Width;
			}
		}

		public int Left {
			get {
				return X;
			}
			set {
				X = value;
			}
		}

		public Rectanglei(int x, int y, int width, int height) {
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		public Rectanglei(Vector2i pos, int width, int height) : this(pos.X, pos.Y, width, height) { }
		public Rectanglei(Vector2i pos, Vector2i size) : this(pos, size.X, size.Y) { }

		public bool Intersects(Rectanglei rect) {
			return !((X >= rect.Right) || (Right <= rect.X) ||
				(Y >= rect.Top) || (Top <= rect.Y));
		}

        public bool Contains(Vector2i vec) {
            return
                (vec.X >= X && vec.X <= Right &&
                vec.Y >= Bottom && vec.Y <= Top);
        }
	}
}

