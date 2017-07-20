using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Jtransforms.Utils {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']"
	[global::Android.Runtime.Register ("org/jtransforms/utils/IOUtils", DoNotGenerateAcw=true)]
	public partial class IOUtils : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/jtransforms/utils/IOUtils", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (IOUtils); }
		}

		protected IOUtils (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_computeRMSE_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='computeRMSE' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("computeRMSE", "(DD)D", "")]
		public static unsafe double ComputeRMSE (double p0, double p1)
		{
			if (id_computeRMSE_DD == IntPtr.Zero)
				id_computeRMSE_DD = JNIEnv.GetStaticMethodID (class_ref, "computeRMSE", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_computeRMSE_DD, __args);
			} finally {
			}
		}

		static IntPtr id_computeRMSE_arrayDarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='computeRMSE' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='double[]']]"
		[Register ("computeRMSE", "([D[D)D", "")]
		public static unsafe double ComputeRMSE (double[] p0, double[] p1)
		{
			if (id_computeRMSE_arrayDarrayD == IntPtr.Zero)
				id_computeRMSE_arrayDarrayD = JNIEnv.GetStaticMethodID (class_ref, "computeRMSE", "([D[D)D");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				double __ret = JNIEnv.CallStaticDoubleMethod  (class_ref, id_computeRMSE_arrayDarrayD, __args);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_computeRMSE_arrayarrayDarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='computeRMSE' and count(parameter)=2 and parameter[1][@type='double[][]'] and parameter[2][@type='double[][]']]"
		[Register ("computeRMSE", "([[D[[D)D", "")]
		public static unsafe double ComputeRMSE (double[][] p0, double[][] p1)
		{
			if (id_computeRMSE_arrayarrayDarrayarrayD == IntPtr.Zero)
				id_computeRMSE_arrayarrayDarrayarrayD = JNIEnv.GetStaticMethodID (class_ref, "computeRMSE", "([[D[[D)D");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				double __ret = JNIEnv.CallStaticDoubleMethod  (class_ref, id_computeRMSE_arrayarrayDarrayarrayD, __args);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_computeRMSE_arrayarrayarrayDarrayarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='computeRMSE' and count(parameter)=2 and parameter[1][@type='double[][][]'] and parameter[2][@type='double[][][]']]"
		[Register ("computeRMSE", "([[[D[[[D)D", "")]
		public static unsafe double ComputeRMSE (double[][][] p0, double[][][] p1)
		{
			if (id_computeRMSE_arrayarrayarrayDarrayarrayarrayD == IntPtr.Zero)
				id_computeRMSE_arrayarrayarrayDarrayarrayarrayD = JNIEnv.GetStaticMethodID (class_ref, "computeRMSE", "([[[D[[[D)D");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				double __ret = JNIEnv.CallStaticDoubleMethod  (class_ref, id_computeRMSE_arrayarrayarrayDarrayarrayarrayD, __args);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_computeRMSE_FF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='computeRMSE' and count(parameter)=2 and parameter[1][@type='float'] and parameter[2][@type='float']]"
		[Register ("computeRMSE", "(FF)D", "")]
		public static unsafe double ComputeRMSE (float p0, float p1)
		{
			if (id_computeRMSE_FF == IntPtr.Zero)
				id_computeRMSE_FF = JNIEnv.GetStaticMethodID (class_ref, "computeRMSE", "(FF)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_computeRMSE_FF, __args);
			} finally {
			}
		}

		static IntPtr id_computeRMSE_arrayFarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='computeRMSE' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='float[]']]"
		[Register ("computeRMSE", "([F[F)D", "")]
		public static unsafe double ComputeRMSE (float[] p0, float[] p1)
		{
			if (id_computeRMSE_arrayFarrayF == IntPtr.Zero)
				id_computeRMSE_arrayFarrayF = JNIEnv.GetStaticMethodID (class_ref, "computeRMSE", "([F[F)D");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				double __ret = JNIEnv.CallStaticDoubleMethod  (class_ref, id_computeRMSE_arrayFarrayF, __args);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_computeRMSE_arrayarrayFarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='computeRMSE' and count(parameter)=2 and parameter[1][@type='float[][]'] and parameter[2][@type='float[][]']]"
		[Register ("computeRMSE", "([[F[[F)D", "")]
		public static unsafe double ComputeRMSE (float[][] p0, float[][] p1)
		{
			if (id_computeRMSE_arrayarrayFarrayarrayF == IntPtr.Zero)
				id_computeRMSE_arrayarrayFarrayarrayF = JNIEnv.GetStaticMethodID (class_ref, "computeRMSE", "([[F[[F)D");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				double __ret = JNIEnv.CallStaticDoubleMethod  (class_ref, id_computeRMSE_arrayarrayFarrayarrayF, __args);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_computeRMSE_arrayarrayarrayFarrayarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='computeRMSE' and count(parameter)=2 and parameter[1][@type='float[][][]'] and parameter[2][@type='float[][][]']]"
		[Register ("computeRMSE", "([[[F[[[F)D", "")]
		public static unsafe double ComputeRMSE (float[][][] p0, float[][][] p1)
		{
			if (id_computeRMSE_arrayarrayarrayFarrayarrayarrayF == IntPtr.Zero)
				id_computeRMSE_arrayarrayarrayFarrayarrayarrayF = JNIEnv.GetStaticMethodID (class_ref, "computeRMSE", "([[[F[[[F)D");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				double __ret = JNIEnv.CallStaticDoubleMethod  (class_ref, id_computeRMSE_arrayarrayarrayFarrayarrayarrayF, __args);
				return __ret;
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_computeRMSE_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='computeRMSE' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("computeRMSE", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Lpl/edu/icm/jlargearrays/DoubleLargeArray;)D", "")]
		public static unsafe double ComputeRMSE (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1)
		{
			if (id_computeRMSE_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_computeRMSE_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "computeRMSE", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;Lpl/edu/icm/jlargearrays/DoubleLargeArray;)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				double __ret = JNIEnv.CallStaticDoubleMethod  (class_ref, id_computeRMSE_Lpl_edu_icm_jlargearrays_DoubleLargeArray_Lpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_computeRMSE_Lpl_edu_icm_jlargearrays_FloatLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='computeRMSE' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("computeRMSE", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Lpl/edu/icm/jlargearrays/FloatLargeArray;)D", "")]
		public static unsafe double ComputeRMSE (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1)
		{
			if (id_computeRMSE_Lpl_edu_icm_jlargearrays_FloatLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_computeRMSE_Lpl_edu_icm_jlargearrays_FloatLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "computeRMSE", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;Lpl/edu/icm/jlargearrays/FloatLargeArray;)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				double __ret = JNIEnv.CallStaticDoubleMethod  (class_ref, id_computeRMSE_Lpl_edu_icm_jlargearrays_FloatLargeArray_Lpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_fillMatrix_1D_JarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_1D' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='double[]']]"
		[Register ("fillMatrix_1D", "(J[D)V", "")]
		public static unsafe void FillMatrix_1D (long p0, double[] p1)
		{
			if (id_fillMatrix_1D_JarrayD == IntPtr.Zero)
				id_fillMatrix_1D_JarrayD = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_1D", "(J[D)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_1D_JarrayD, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_fillMatrix_1D_JarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_1D' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='float[]']]"
		[Register ("fillMatrix_1D", "(J[F)V", "")]
		public static unsafe void FillMatrix_1D (long p0, float[] p1)
		{
			if (id_fillMatrix_1D_JarrayF == IntPtr.Zero)
				id_fillMatrix_1D_JarrayF = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_1D", "(J[F)V");
			IntPtr native_p1 = JNIEnv.NewArray (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_1D_JarrayF, __args);
			} finally {
				if (p1 != null) {
					JNIEnv.CopyArray (native_p1, p1);
					JNIEnv.DeleteLocalRef (native_p1);
				}
			}
		}

		static IntPtr id_fillMatrix_1D_JLpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_1D' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("fillMatrix_1D", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public static unsafe void FillMatrix_1D (long p0, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p1)
		{
			if (id_fillMatrix_1D_JLpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_fillMatrix_1D_JLpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_1D", "(JLpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_1D_JLpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_fillMatrix_1D_JLpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_1D' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("fillMatrix_1D", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public static unsafe void FillMatrix_1D (long p0, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p1)
		{
			if (id_fillMatrix_1D_JLpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_fillMatrix_1D_JLpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_1D", "(JLpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_1D_JLpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_fillMatrix_2D_JJarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_2D' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='double[]']]"
		[Register ("fillMatrix_2D", "(JJ[D)V", "")]
		public static unsafe void FillMatrix_2D (long p0, long p1, double[] p2)
		{
			if (id_fillMatrix_2D_JJarrayD == IntPtr.Zero)
				id_fillMatrix_2D_JJarrayD = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_2D", "(JJ[D)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_2D_JJarrayD, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_fillMatrix_2D_JJarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_2D' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='double[][]']]"
		[Register ("fillMatrix_2D", "(JJ[[D)V", "")]
		public static unsafe void FillMatrix_2D (long p0, long p1, double[][] p2)
		{
			if (id_fillMatrix_2D_JJarrayarrayD == IntPtr.Zero)
				id_fillMatrix_2D_JJarrayarrayD = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_2D", "(JJ[[D)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_2D_JJarrayarrayD, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_fillMatrix_2D_JJarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_2D' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='float[]']]"
		[Register ("fillMatrix_2D", "(JJ[F)V", "")]
		public static unsafe void FillMatrix_2D (long p0, long p1, float[] p2)
		{
			if (id_fillMatrix_2D_JJarrayF == IntPtr.Zero)
				id_fillMatrix_2D_JJarrayF = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_2D", "(JJ[F)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_2D_JJarrayF, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_fillMatrix_2D_JJarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_2D' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='float[][]']]"
		[Register ("fillMatrix_2D", "(JJ[[F)V", "")]
		public static unsafe void FillMatrix_2D (long p0, long p1, float[][] p2)
		{
			if (id_fillMatrix_2D_JJarrayarrayF == IntPtr.Zero)
				id_fillMatrix_2D_JJarrayarrayF = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_2D", "(JJ[[F)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_2D_JJarrayarrayF, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
			}
		}

		static IntPtr id_fillMatrix_2D_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_2D' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("fillMatrix_2D", "(JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public static unsafe void FillMatrix_2D (long p0, long p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2)
		{
			if (id_fillMatrix_2D_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_fillMatrix_2D_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_2D", "(JJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_2D_JJLpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_fillMatrix_2D_JJLpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_2D' and count(parameter)=3 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("fillMatrix_2D", "(JJLpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public static unsafe void FillMatrix_2D (long p0, long p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2)
		{
			if (id_fillMatrix_2D_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_fillMatrix_2D_JJLpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_2D", "(JJLpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_2D_JJLpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_fillMatrix_3D_JJJarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_3D' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='double[]']]"
		[Register ("fillMatrix_3D", "(JJJ[D)V", "")]
		public static unsafe void FillMatrix_3D (long p0, long p1, long p2, double[] p3)
		{
			if (id_fillMatrix_3D_JJJarrayD == IntPtr.Zero)
				id_fillMatrix_3D_JJJarrayD = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_3D", "(JJJ[D)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_3D_JJJarrayD, __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_fillMatrix_3D_JJJarrayarrayarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_3D' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='double[][][]']]"
		[Register ("fillMatrix_3D", "(JJJ[[[D)V", "")]
		public static unsafe void FillMatrix_3D (long p0, long p1, long p2, double[][][] p3)
		{
			if (id_fillMatrix_3D_JJJarrayarrayarrayD == IntPtr.Zero)
				id_fillMatrix_3D_JJJarrayarrayarrayD = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_3D", "(JJJ[[[D)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_3D_JJJarrayarrayarrayD, __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_fillMatrix_3D_JJJarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_3D' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='float[]']]"
		[Register ("fillMatrix_3D", "(JJJ[F)V", "")]
		public static unsafe void FillMatrix_3D (long p0, long p1, long p2, float[] p3)
		{
			if (id_fillMatrix_3D_JJJarrayF == IntPtr.Zero)
				id_fillMatrix_3D_JJJarrayF = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_3D", "(JJJ[F)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_3D_JJJarrayF, __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_fillMatrix_3D_JJJarrayarrayarrayF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_3D' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='float[][][]']]"
		[Register ("fillMatrix_3D", "(JJJ[[[F)V", "")]
		public static unsafe void FillMatrix_3D (long p0, long p1, long p2, float[][][] p3)
		{
			if (id_fillMatrix_3D_JJJarrayarrayarrayF == IntPtr.Zero)
				id_fillMatrix_3D_JJJarrayarrayarrayF = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_3D", "(JJJ[[[F)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_3D_JJJarrayarrayarrayF, __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
			}
		}

		static IntPtr id_fillMatrix_3D_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_3D' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.DoubleLargeArray']]"
		[Register ("fillMatrix_3D", "(JJJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V", "")]
		public static unsafe void FillMatrix_3D (long p0, long p1, long p2, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p3)
		{
			if (id_fillMatrix_3D_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_ == IntPtr.Zero)
				id_fillMatrix_3D_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_3D", "(JJJLpl/edu/icm/jlargearrays/DoubleLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_3D_JJJLpl_edu_icm_jlargearrays_DoubleLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_fillMatrix_3D_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='fillMatrix_3D' and count(parameter)=4 and parameter[1][@type='long'] and parameter[2][@type='long'] and parameter[3][@type='long'] and parameter[4][@type='pl.edu.icm.jlargearrays.FloatLargeArray']]"
		[Register ("fillMatrix_3D", "(JJJLpl/edu/icm/jlargearrays/FloatLargeArray;)V", "")]
		public static unsafe void FillMatrix_3D (long p0, long p1, long p2, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p3)
		{
			if (id_fillMatrix_3D_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_ == IntPtr.Zero)
				id_fillMatrix_3D_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "fillMatrix_3D", "(JJJLpl/edu/icm/jlargearrays/FloatLargeArray;)V");
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_fillMatrix_3D_JJJLpl_edu_icm_jlargearrays_FloatLargeArray_, __args);
			} finally {
			}
		}

		static IntPtr id_showComplex_1D_arrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='showComplex_1D' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='java.lang.String']]"
		[Register ("showComplex_1D", "([DLjava/lang/String;)V", "")]
		public static unsafe void ShowComplex_1D (double[] p0, string p1)
		{
			if (id_showComplex_1D_arrayDLjava_lang_String_ == IntPtr.Zero)
				id_showComplex_1D_arrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showComplex_1D", "([DLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showComplex_1D_arrayDLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_showComplex_2D_arrayarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='showComplex_2D' and count(parameter)=2 and parameter[1][@type='double[][]'] and parameter[2][@type='java.lang.String']]"
		[Register ("showComplex_2D", "([[DLjava/lang/String;)V", "")]
		public static unsafe void ShowComplex_2D (double[][] p0, string p1)
		{
			if (id_showComplex_2D_arrayarrayDLjava_lang_String_ == IntPtr.Zero)
				id_showComplex_2D_arrayarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showComplex_2D", "([[DLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showComplex_2D_arrayarrayDLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_showComplex_2D_IIarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='showComplex_2D' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='double[]'] and parameter[4][@type='java.lang.String']]"
		[Register ("showComplex_2D", "(II[DLjava/lang/String;)V", "")]
		public static unsafe void ShowComplex_2D (int p0, int p1, double[] p2, string p3)
		{
			if (id_showComplex_2D_IIarrayDLjava_lang_String_ == IntPtr.Zero)
				id_showComplex_2D_IIarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showComplex_2D", "(II[DLjava/lang/String;)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showComplex_2D_IIarrayDLjava_lang_String_, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				JNIEnv.DeleteLocalRef (native_p3);
			}
		}

		static IntPtr id_showComplex_3D_arrayarrayarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='showComplex_3D' and count(parameter)=2 and parameter[1][@type='double[][][]'] and parameter[2][@type='java.lang.String']]"
		[Register ("showComplex_3D", "([[[DLjava/lang/String;)V", "")]
		public static unsafe void ShowComplex_3D (double[][][] p0, string p1)
		{
			if (id_showComplex_3D_arrayarrayarrayDLjava_lang_String_ == IntPtr.Zero)
				id_showComplex_3D_arrayarrayarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showComplex_3D", "([[[DLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showComplex_3D_arrayarrayarrayDLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_showComplex_3D_IIIarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='showComplex_3D' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='java.lang.String']]"
		[Register ("showComplex_3D", "(III[DLjava/lang/String;)V", "")]
		public static unsafe void ShowComplex_3D (int p0, int p1, int p2, double[] p3, string p4)
		{
			if (id_showComplex_3D_IIIarrayDLjava_lang_String_ == IntPtr.Zero)
				id_showComplex_3D_IIIarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showComplex_3D", "(III[DLjava/lang/String;)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showComplex_3D_IIIarrayDLjava_lang_String_, __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				JNIEnv.DeleteLocalRef (native_p4);
			}
		}

		static IntPtr id_showComplex_3D_IIIarrayFLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='showComplex_3D' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='float[]'] and parameter[5][@type='java.lang.String']]"
		[Register ("showComplex_3D", "(III[FLjava/lang/String;)V", "")]
		public static unsafe void ShowComplex_3D (int p0, int p1, int p2, float[] p3, string p4)
		{
			if (id_showComplex_3D_IIIarrayFLjava_lang_String_ == IntPtr.Zero)
				id_showComplex_3D_IIIarrayFLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showComplex_3D", "(III[FLjava/lang/String;)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showComplex_3D_IIIarrayFLjava_lang_String_, __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				JNIEnv.DeleteLocalRef (native_p4);
			}
		}

		static IntPtr id_showReal_1D_arrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='showReal_1D' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='java.lang.String']]"
		[Register ("showReal_1D", "([DLjava/lang/String;)V", "")]
		public static unsafe void ShowReal_1D (double[] p0, string p1)
		{
			if (id_showReal_1D_arrayDLjava_lang_String_ == IntPtr.Zero)
				id_showReal_1D_arrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showReal_1D", "([DLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showReal_1D_arrayDLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_showReal_2D_IIarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='showReal_2D' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='double[]'] and parameter[4][@type='java.lang.String']]"
		[Register ("showReal_2D", "(II[DLjava/lang/String;)V", "")]
		public static unsafe void ShowReal_2D (int p0, int p1, double[] p2, string p3)
		{
			if (id_showReal_2D_IIarrayDLjava_lang_String_ == IntPtr.Zero)
				id_showReal_2D_IIarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showReal_2D", "(II[DLjava/lang/String;)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showReal_2D_IIarrayDLjava_lang_String_, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				JNIEnv.DeleteLocalRef (native_p3);
			}
		}

		static IntPtr id_showReal_3D_arrayarrayarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='showReal_3D' and count(parameter)=2 and parameter[1][@type='double[][][]'] and parameter[2][@type='java.lang.String']]"
		[Register ("showReal_3D", "([[[DLjava/lang/String;)V", "")]
		public static unsafe void ShowReal_3D (double[][][] p0, string p1)
		{
			if (id_showReal_3D_arrayarrayarrayDLjava_lang_String_ == IntPtr.Zero)
				id_showReal_3D_arrayarrayarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showReal_3D", "([[[DLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showReal_3D_arrayarrayarrayDLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_showReal_3D_IIIarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='showReal_3D' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='java.lang.String']]"
		[Register ("showReal_3D", "(III[DLjava/lang/String;)V", "")]
		public static unsafe void ShowReal_3D (int p0, int p1, int p2, double[] p3, string p4)
		{
			if (id_showReal_3D_IIIarrayDLjava_lang_String_ == IntPtr.Zero)
				id_showReal_3D_IIIarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "showReal_3D", "(III[DLjava/lang/String;)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_showReal_3D_IIIarrayDLjava_lang_String_, __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				JNIEnv.DeleteLocalRef (native_p4);
			}
		}

		static IntPtr id_writeFFTBenchmarkResultsToFile_Ljava_lang_String_IIZZarrayJarrayDarrayD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeFFTBenchmarkResultsToFile' and count(parameter)=8 and parameter[1][@type='java.lang.String'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='boolean'] and parameter[5][@type='boolean'] and parameter[6][@type='long[]'] and parameter[7][@type='double[]'] and parameter[8][@type='double[]']]"
		[Register ("writeFFTBenchmarkResultsToFile", "(Ljava/lang/String;IIZZ[J[D[D)V", "")]
		public static unsafe void WriteFFTBenchmarkResultsToFile (string p0, int p1, int p2, bool p3, bool p4, long[] p5, double[] p6, double[] p7)
		{
			if (id_writeFFTBenchmarkResultsToFile_Ljava_lang_String_IIZZarrayJarrayDarrayD == IntPtr.Zero)
				id_writeFFTBenchmarkResultsToFile_Ljava_lang_String_IIZZarrayJarrayDarrayD = JNIEnv.GetStaticMethodID (class_ref, "writeFFTBenchmarkResultsToFile", "(Ljava/lang/String;IIZZ[J[D[D)V");
			IntPtr native_p0 = JNIEnv.NewString (p0);
			IntPtr native_p5 = JNIEnv.NewArray (p5);
			IntPtr native_p6 = JNIEnv.NewArray (p6);
			IntPtr native_p7 = JNIEnv.NewArray (p7);
			try {
				JValue* __args = stackalloc JValue [8];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				__args [5] = new JValue (native_p5);
				__args [6] = new JValue (native_p6);
				__args [7] = new JValue (native_p7);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeFFTBenchmarkResultsToFile_Ljava_lang_String_IIZZarrayJarrayDarrayD, __args);
			} finally {
				JNIEnv.DeleteLocalRef (native_p0);
				if (p5 != null) {
					JNIEnv.CopyArray (native_p5, p5);
					JNIEnv.DeleteLocalRef (native_p5);
				}
				if (p6 != null) {
					JNIEnv.CopyArray (native_p6, p6);
					JNIEnv.DeleteLocalRef (native_p6);
				}
				if (p7 != null) {
					JNIEnv.CopyArray (native_p7, p7);
					JNIEnv.DeleteLocalRef (native_p7);
				}
			}
		}

		static IntPtr id_writeToFileComplex_1D_arrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileComplex_1D' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='java.lang.String']]"
		[Register ("writeToFileComplex_1D", "([DLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileComplex_1D (double[] p0, string p1)
		{
			if (id_writeToFileComplex_1D_arrayDLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileComplex_1D_arrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileComplex_1D", "([DLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileComplex_1D_arrayDLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_writeToFileComplex_1D_arrayFLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileComplex_1D' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='java.lang.String']]"
		[Register ("writeToFileComplex_1D", "([FLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileComplex_1D (float[] p0, string p1)
		{
			if (id_writeToFileComplex_1D_arrayFLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileComplex_1D_arrayFLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileComplex_1D", "([FLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileComplex_1D_arrayFLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_writeToFileComplex_2D_arrayarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileComplex_2D' and count(parameter)=2 and parameter[1][@type='double[][]'] and parameter[2][@type='java.lang.String']]"
		[Register ("writeToFileComplex_2D", "([[DLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileComplex_2D (double[][] p0, string p1)
		{
			if (id_writeToFileComplex_2D_arrayarrayDLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileComplex_2D_arrayarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileComplex_2D", "([[DLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileComplex_2D_arrayarrayDLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_writeToFileComplex_2D_IIarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileComplex_2D' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='double[]'] and parameter[4][@type='java.lang.String']]"
		[Register ("writeToFileComplex_2D", "(II[DLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileComplex_2D (int p0, int p1, double[] p2, string p3)
		{
			if (id_writeToFileComplex_2D_IIarrayDLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileComplex_2D_IIarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileComplex_2D", "(II[DLjava/lang/String;)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileComplex_2D_IIarrayDLjava_lang_String_, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				JNIEnv.DeleteLocalRef (native_p3);
			}
		}

		static IntPtr id_writeToFileComplex_2D_IIarrayFLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileComplex_2D' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='float[]'] and parameter[4][@type='java.lang.String']]"
		[Register ("writeToFileComplex_2D", "(II[FLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileComplex_2D (int p0, int p1, float[] p2, string p3)
		{
			if (id_writeToFileComplex_2D_IIarrayFLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileComplex_2D_IIarrayFLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileComplex_2D", "(II[FLjava/lang/String;)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileComplex_2D_IIarrayFLjava_lang_String_, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				JNIEnv.DeleteLocalRef (native_p3);
			}
		}

		static IntPtr id_writeToFileComplex_3D_arrayarrayarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileComplex_3D' and count(parameter)=2 and parameter[1][@type='double[][][]'] and parameter[2][@type='java.lang.String']]"
		[Register ("writeToFileComplex_3D", "([[[DLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileComplex_3D (double[][][] p0, string p1)
		{
			if (id_writeToFileComplex_3D_arrayarrayarrayDLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileComplex_3D_arrayarrayarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileComplex_3D", "([[[DLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileComplex_3D_arrayarrayarrayDLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_writeToFileComplex_3D_IIIarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileComplex_3D' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='java.lang.String']]"
		[Register ("writeToFileComplex_3D", "(III[DLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileComplex_3D (int p0, int p1, int p2, double[] p3, string p4)
		{
			if (id_writeToFileComplex_3D_IIIarrayDLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileComplex_3D_IIIarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileComplex_3D", "(III[DLjava/lang/String;)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileComplex_3D_IIIarrayDLjava_lang_String_, __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				JNIEnv.DeleteLocalRef (native_p4);
			}
		}

		static IntPtr id_writeToFileReal_1D_arrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileReal_1D' and count(parameter)=2 and parameter[1][@type='double[]'] and parameter[2][@type='java.lang.String']]"
		[Register ("writeToFileReal_1D", "([DLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileReal_1D (double[] p0, string p1)
		{
			if (id_writeToFileReal_1D_arrayDLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileReal_1D_arrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileReal_1D", "([DLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileReal_1D_arrayDLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_writeToFileReal_1D_arrayFLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileReal_1D' and count(parameter)=2 and parameter[1][@type='float[]'] and parameter[2][@type='java.lang.String']]"
		[Register ("writeToFileReal_1D", "([FLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileReal_1D (float[] p0, string p1)
		{
			if (id_writeToFileReal_1D_arrayFLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileReal_1D_arrayFLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileReal_1D", "([FLjava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			IntPtr native_p1 = JNIEnv.NewString (p1);
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (native_p1);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileReal_1D_arrayFLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
				JNIEnv.DeleteLocalRef (native_p1);
			}
		}

		static IntPtr id_writeToFileReal_2D_IIarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileReal_2D' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='double[]'] and parameter[4][@type='java.lang.String']]"
		[Register ("writeToFileReal_2D", "(II[DLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileReal_2D (int p0, int p1, double[] p2, string p3)
		{
			if (id_writeToFileReal_2D_IIarrayDLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileReal_2D_IIarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileReal_2D", "(II[DLjava/lang/String;)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileReal_2D_IIarrayDLjava_lang_String_, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				JNIEnv.DeleteLocalRef (native_p3);
			}
		}

		static IntPtr id_writeToFileReal_2D_IIarrayFLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileReal_2D' and count(parameter)=4 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='float[]'] and parameter[4][@type='java.lang.String']]"
		[Register ("writeToFileReal_2D", "(II[FLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileReal_2D (int p0, int p1, float[] p2, string p3)
		{
			if (id_writeToFileReal_2D_IIarrayFLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileReal_2D_IIarrayFLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileReal_2D", "(II[FLjava/lang/String;)V");
			IntPtr native_p2 = JNIEnv.NewArray (p2);
			IntPtr native_p3 = JNIEnv.NewString (p3);
			try {
				JValue* __args = stackalloc JValue [4];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (native_p2);
				__args [3] = new JValue (native_p3);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileReal_2D_IIarrayFLjava_lang_String_, __args);
			} finally {
				if (p2 != null) {
					JNIEnv.CopyArray (native_p2, p2);
					JNIEnv.DeleteLocalRef (native_p2);
				}
				JNIEnv.DeleteLocalRef (native_p3);
			}
		}

		static IntPtr id_writeToFileReal_3D_IIIarrayDLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.jtransforms.utils']/class[@name='IOUtils']/method[@name='writeToFileReal_3D' and count(parameter)=5 and parameter[1][@type='int'] and parameter[2][@type='int'] and parameter[3][@type='int'] and parameter[4][@type='double[]'] and parameter[5][@type='java.lang.String']]"
		[Register ("writeToFileReal_3D", "(III[DLjava/lang/String;)V", "")]
		public static unsafe void WriteToFileReal_3D (int p0, int p1, int p2, double[] p3, string p4)
		{
			if (id_writeToFileReal_3D_IIIarrayDLjava_lang_String_ == IntPtr.Zero)
				id_writeToFileReal_3D_IIIarrayDLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "writeToFileReal_3D", "(III[DLjava/lang/String;)V");
			IntPtr native_p3 = JNIEnv.NewArray (p3);
			IntPtr native_p4 = JNIEnv.NewString (p4);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (native_p3);
				__args [4] = new JValue (native_p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_writeToFileReal_3D_IIIarrayDLjava_lang_String_, __args);
			} finally {
				if (p3 != null) {
					JNIEnv.CopyArray (native_p3, p3);
					JNIEnv.DeleteLocalRef (native_p3);
				}
				JNIEnv.DeleteLocalRef (native_p4);
			}
		}

	}
}
