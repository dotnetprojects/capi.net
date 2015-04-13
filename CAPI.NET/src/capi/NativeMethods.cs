namespace Mommosoft.Capi {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;

    internal class NativeMethods {
        
        [DllImport("CAPI2032.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_PUT_MESSAGE")]
        public extern static int CAPI_PUT_MESSAGE32(int ApplID, IntPtr pCAPIMessage);

        [DllImport("CAPI2064.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_PUT_MESSAGE")]
        public extern static int CAPI_PUT_MESSAGE64(int ApplID, IntPtr pCAPIMessage);

        public static int CAPI_PUT_MESSAGE(int ApplID, IntPtr pCAPIMessage)
        {
            if (IntPtr.Size == 8)
                return CAPI_PUT_MESSAGE64(ApplID, pCAPIMessage);
            else
                return CAPI_PUT_MESSAGE32(ApplID, pCAPIMessage);
        }

        [DllImport("CAPI2032.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_GET_MESSAGE")]
        public extern static int CAPI_GET_MESSAGE32(int ApplID, out IntPtr ppCAPIMessage);

        [DllImport("CAPI2064.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_GET_MESSAGE")]
        public extern static int CAPI_GET_MESSAGE64(int ApplID, out IntPtr ppCAPIMessage);

        public static int CAPI_GET_MESSAGE(int ApplID, out IntPtr ppCAPIMessage)
        {
            if (IntPtr.Size == 8)
                return CAPI_GET_MESSAGE64(ApplID, out ppCAPIMessage);
            else
                return CAPI_GET_MESSAGE32(ApplID, out ppCAPIMessage);
        }

        [DllImport("CAPI2032.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_REGISTER")]
        public extern static int CAPI_REGISTER32(int MessageBufferSize,
                                                int maxLogicalConnection,
                                                int maxBDataBlocks,
                                                int maxBDataLen,
                                                out int pApplID);

        [DllImport("CAPI2064.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_REGISTER")]
        public extern static int CAPI_REGISTER64(int MessageBufferSize,
                                                int maxLogicalConnection,
                                                int maxBDataBlocks,
                                                int maxBDataLen,
                                                out int pApplID);


        /// <summary>
        /// This is the function the application uses to announce its presence to COMMONISDN-API.
        /// </summary>
        /// <param name="MessageBufferSize">Size of Message Buffer</param>
        /// <param name="maxLogicalConnection">Maximum number of logical connections</param>
        /// <param name="maxBDataBlocks">Number of data blocks available simultaneously</param>
        /// <param name="maxBDataLen">Maximum size of a data block</param>
        /// <param name="pApplID">Pointer to the location where COMMON-ISDN-API should place the assigned
        /// application identification number </param>
        /// <returns>returned code
        /// <example>0x000 Registration successful: application identification number has been assigned</example>
        /// <remarks>Coded as described in parameter Info, class 0x10xx</remarks>
        /// </returns>
        public static int CAPI_REGISTER(int MessageBufferSize,
            int maxLogicalConnection,
            int maxBDataBlocks,
            int maxBDataLen,
            out int pApplID)
        {
            if (IntPtr.Size == 8)
                return CAPI_REGISTER64(MessageBufferSize, maxLogicalConnection, maxBDataBlocks, maxBDataLen, out pApplID);
            else
                return CAPI_REGISTER32(MessageBufferSize, maxLogicalConnection, maxBDataBlocks, maxBDataLen, out pApplID);
        }

        [DllImport("CAPI2032.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_RELEASE")]
        public extern static int CAPI_RELEASE32(int ApplID);

        [DllImport("CAPI2064.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_RELEASE")]
        public extern static int CAPI_RELEASE64(int ApplID);

        public static int CAPI_RELEASE(int ApplID)
        {
            if (IntPtr.Size == 8)
                return CAPI_RELEASE64(ApplID);
            else
                return CAPI_RELEASE32(ApplID);
        }

        [DllImport("CAPI2032.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_GET_VERSION")]
        public extern static int CAPI_GET_VERSION32(out int pCAPIMajor,
                                                    out int pCAPIMinor,
                                                    out int pManufacturerMajor,
                                                    out int pManufacturerMinor);

        [DllImport("CAPI2064.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_GET_VERSION")]
        public extern static int CAPI_GET_VERSION64(out int pCAPIMajor,
                                                    out int pCAPIMinor,
                                                    out int pManufacturerMajor,
                                                    out int pManufacturerMinor);

        /// <summary>
        /// Obtains the version of COMMON-ISDN-API as well as an internal revision number.
        /// </summary>
        /// <param name="pCAPIMajor">Pointer to a DWORD which will receive the COMMON-ISDN-API major version number: 2.</param>
        /// <param name="pCAPIMinor">Pointer to a DWORD which will receive the COMMON-ISDN-API minor version number: 0.</param>
        /// <param name="pManufacturerMajor">Pointer to a DWORD which will receive the manufacturer-specific major number.</param>
        /// <param name="pManufacturerMinor">Pointer to a DWORD which will receive the manufacturer-specific minor number.</param>
        /// <returns></returns>
        public static int CAPI_GET_VERSION(out int pCAPIMajor,
            out int pCAPIMinor,
            out int pManufacturerMajor,
            out int pManufacturerMinor)
        {
            if (IntPtr.Size == 8)
                return CAPI_GET_VERSION64(out pCAPIMajor, out pCAPIMinor, out pManufacturerMajor, out pManufacturerMinor);
            else
                return CAPI_GET_VERSION32(out pCAPIMajor, out pCAPIMinor, out pManufacturerMajor, out pManufacturerMinor);
        }

        [DllImport("CAPI2032.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_GET_MANUFACTURER")]
        public extern static void CAPI_GET_MANUFACTURER32([Out] StringBuilder buffer);

        [DllImport("CAPI2064.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_GET_MANUFACTURER")]
        public extern static void CAPI_GET_MANUFACTURER64([Out] StringBuilder buffer);

        /// <summary>
        /// Obtains the manufacturer identification of COMMON-ISDN-API (DLL).
        /// </summary>
        /// <param name="buffer" remarks = "64 bytes including null terminating 0>buffer of 64 bytes</param>
        public static void CAPI_GET_MANUFACTURER([Out] StringBuilder buffer)
        {
            if (IntPtr.Size == 8)
                CAPI_GET_MANUFACTURER64(buffer);
            else
                CAPI_GET_MANUFACTURER32(buffer);
        }

        [DllImport("CAPI2032.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_GET_SERIAL_NUMBER")]
        public extern static void CAPI_GET_SERIAL_NUMBER32([Out] StringBuilder buffer);

        [DllImport("CAPI2064.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_GET_SERIAL_NUMBER")]
        public extern static void CAPI_GET_SERIAL_NUMBER64([Out] StringBuilder buffer);

        /// <summary>
        /// obtains the (optional) serial number of COMMON-ISDN-API.
        /// </summary>
        /// <param name="buffer">SzBuffer on call is a pointer to a buffer of 8 bytes.</param>
        public static void CAPI_GET_SERIAL_NUMBER([Out] StringBuilder buffer)
        {
            if (IntPtr.Size == 8)
                CAPI_GET_SERIAL_NUMBER64(buffer);
            else
                CAPI_GET_SERIAL_NUMBER32(buffer);
        }

        [DllImport("CAPI2032.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_WAIT_FOR_SIGNAL")]
        public extern static int CAPI_WAIT_FOR_SIGNAL32(int ApplID);

        [DllImport("CAPI2064.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_WAIT_FOR_SIGNAL")]
        public extern static int CAPI_WAIT_FOR_SIGNAL64(int ApplID);

        /// <summary>
        /// used by the application to wait for an asynchronous event from COMMON-ISDN-API.
        /// </summary>
        /// <param name="ApplID"></param>
        public static int CAPI_WAIT_FOR_SIGNAL(int ApplID)
        {
            if (IntPtr.Size == 8)
                return CAPI_WAIT_FOR_SIGNAL64(ApplID);
            else
                return CAPI_WAIT_FOR_SIGNAL32(ApplID);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Profile {
            public Int16 number;           //Number of installed ISDN controllers (=cards) */
            public Int16 channels;	        //Number of "B" channels supported */
            public int global_Options;
            public int B1_Protocols;
            public int B2_Protocols;
            public int B3_Protocols;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
            public int[] spare;     //prevents things being overwritten
        }

        [Flags]
        public enum B1Protocol {
            HDLC64K = 0x0001,
            T64K = 0x0002,
            V110A = 0x004,
            V110S = 0x008,
            T30 = 0x0010,
            HDLC64KINV = 0x0020
        }

        [DllImport("CAPI2032.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_GET_PROFILE")]
        public extern static int CAPI_GET_PROFILE32(ref Profile profile, uint controller);

        [DllImport("CAPI2064.DLL", CharSet = CharSet.Ansi, EntryPoint = "CAPI_GET_PROFILE")]
        public extern static int CAPI_GET_PROFILE64(ref Profile profile, uint controller);

        public static int CAPI_GET_PROFILE(ref Profile profile, uint controller)
        {
            if (IntPtr.Size == 8)
                return CAPI_GET_PROFILE64(ref profile, controller);
            else
                return CAPI_GET_PROFILE32(ref profile, controller);
        }

    }
}
