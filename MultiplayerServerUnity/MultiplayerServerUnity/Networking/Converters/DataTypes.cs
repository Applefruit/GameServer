using System;

public struct Vector3
    {
        public static Vector3 Zero
        {
            get { return new Vector3(0, 0, 0); }
        }

        public static Vector3 One
        {
            get { return new Vector3(1, 1, 1); }
        }

        private float m_X;

        public float X
        {
            get { return m_X; }
            set { m_X = value; }
        }

        private float m_Y;
        public float Y
        {
            get { return m_Y; }
            set { m_Y = value; }
        }

        private float m_Z;
        public float Z
        {
            get { return m_Z; }
            set { m_Z = value; }
        }

        public Vector3(float x, float y, float z)
        {
            m_X = x;
            m_Y = y;
            m_Z = z;
        }

        public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }

        public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }

        public static double GetDistance(Vector3 v1, Vector3 v2)
        {
            double x = (double)(v1.X - v2.X);
            double y = (double)(v1.Y - v2.Y);
            double z = (double)(v1.Z - v2.Z);

            return Math.Sqrt(x * x + y * y + z * z);
        }
    }

