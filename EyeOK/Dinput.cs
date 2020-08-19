using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;

////调用示例：
////（先将MSTSA_x86换成对应的项目名称，需要编译在x86,，需要编译在x86，需要编译在x86!!!）
////鼠标滚轮必须的参数必须±120（代表一格？），否则无效
////Dinput.KeyDown(14);//Key.Backspace，函数包含键盘回弹
////附：键盘扫描码
////Application E0 5D 
////Backspace 00 0E 
////Caps Lock 00 3A 
////Delete E0 53 
////End E0 4F 
////Enter 00 1C 
////Escape 00 01 
////HOME E0 47 
////Insert E0 52 
////Left Alt 00 38 
////Left Ctrl 00 1D 
////Left Shift 00 2A 
////Left Windows E0 5B 
////Num Lock 00 45 
////Page Down E0 51 
////Page Up E0 49 
////Power E0 5E 
////PrtSc E0 37 
////Right Alt E0 38 
////Right Ctrl E0 1D 
////Right Shift 00 36 
////Right Windows E0 5C 
////Scroll Lock 00 46 
////Sleep E0 5F 
////Space 00 39 
////Tab 00 0F 
////Wake E0 63

////数字小键盘

////0 00 52 
////1 00 4F 
////2 00 50 
////3 00 51 
////4 00 4B 
////5 00 4C 
////6 00 4D 
////7 00 47 
////8 00 48 
////9 00 49 
////- 00 4A 
////* 00 37 
////. 00 53 
///// 00 35 
////+ 00 4E 
////Enter E0 1C

////功能键

////F1 00 3B 
////F2 00 3C 
////F3 00 3D 
////F4 00 3E 
////F5 00 3F 
////F6 00 40 
////F7 00 41 
////F8 00 42 
////F9 00 43 
////F10 00 44 
////F11 00 57 
////F12 00 58 
////F13 00 64 
////F14 00 65 
////F15 00 66 

////箭头键

////Down E0 50 
////Left E0 4B 
////Right E0 4D 
////Up E0 48

////应用程序键

////Calculator E0 21 
////E-Mail E0 6C 
////Media Select E0 6D 
////Messenger E0 11 
////My Computer E0 6B

////QWERTY键

////' " 00 28 
////- _ 00 0C 
////, < 00 33 
////. > 00 34 
///// ? 00 35 
////; : 00 27 
////[ { 00 1A 
////| 00 2B 
////] } 00 1B 
////` ~ 00 29 
////= + 00 0D 
////0 ) 00 0B 
////1 ! 00 02 
////2 @ 00 03 
////3 # 00 04 
////4 $ 00 05 
////5 % 00 06 
////6 ^ 00 07 
////7 & 00 08 
////8 * 00 09 
////9 ( 00 0A 
////A 00 1E 
////B 00 30 
////C 00 2E 
////D 00 20 
////E 00 12 
////F 00 21 
////G 00 22 
////H 00 23 
////I 00 17 
////J 00 24 
////K 00 25 
////L 00 26 
////M 00 32 
////N 00 31 
////O 00 18 
////P 00 19 
////Q 00 10 
////R 00 13 
////S 00 1F 
////T 00 14 
////U 00 16 
////V 00 2F 
////W 00 11 
////X 00 2D 
////Y 00 15 
////Z 00 2C

////F-Lock键

////Close E0 40 
////Fwd E0 42 
////Help E0 3B 
////New E0 3E 
////Office Home E0 3C 
////Open E0 3F 
////Print E0 58 
////Redo E0 07 
////Reply E0 41 
////Save E0 57 
////Send E0 43 
////Spell E0 23 
////Task Pane E0 3D 
////Undo E0 08

////多媒体播放键

////Mute E0 20 
////Next Track E0 19 
////Play/Pause E0 22 
////Prev Track E0 10 
////Stop E0 24 
////Volume Down E0 2E 
////Volume Up E0 30

////非英文键

////¥ - 00 7D 
////€ E0 45

////国际键盘

////Next to Enter E0 2B 
////Next to L-Shift E0 56

////Brazilian键盘

////Next to R-Shift E0 73

////Far East键盘

////DBE_KATAKANA E0 70 
////DBE_SBCSCHAR E0 77 
////CONVERT E0 79 
////NONCONVERT E0 7B

////Dell键盘上的特殊键

////Internet E0 01

////Logitech键盘上的特殊键

////iTouch E0 13 
////Shopping E0 04 
////Webcam E0 12

////浏览器键

////Back E0 6A 
////Favorites E0 66 
////Forward E0 69 
////HOME E0 32 
////Refresh E0 67 
////Search E0 65 
////Stop E0 68

////微软自然多媒体键盘

////My Pictures E0 64 
////My Music E0 3C 
////Mute E0 20 
////Play/Pause E0 22 
////Stop E0 24 
////+ (Volume up) E0 30 
////- (Volume down) E0 2E 
////|<< (Previous) E0 10 
////>>| (Next) E0 19 
////Media E0 6D 
////Mail E0 6C 
////Web/Home E0 32 
////Messenger E0 05 
////Calculator E0 21

////Log Off E0 16 
////Sleep E0 5F 
////Help(on F1 key) E0 3B 
////Undo(on F2 key) E0 08 
////Redo(on F3 key) E0 07

////Fwd (on F8 key) E0 42 
////Send(on F9 key) E0 43 
////Spell(on F10 key) E0 23 
////Save(on F11 key) E0 57 
////Print(on F12 key) E0 58

namespace EyeOK
{
    public abstract class Dinput
    {
        public const int INPUT_MOUSE = 0;
        public const int INPUT_KEYBOARD = 1;
        public const int KEYEVENTF_KEYUP = 0x0002;
        public const int KEYEVENTF_UNICODE = 0x0004;
        public const int KEYEVENTF_SCANCODE = 0x0008;
        public const int MouseEvent_Absolute = 0x8000;
        public const int MouserEvent_Hwheel = 0x01000;
        public const int MouseEvent_Move = 0x0001;
        public const int MouseEvent_Move_noCoalesce = 0x2000;
        public const int MouseEvent_LeftDown = 0x0002;
        public const int MouseEvent_LeftUp = 0x0004;
        public const int MouseEvent_MiddleDown = 0x0020;
        public const int MouseEvent_MiddleUp = 0x0040;
        public const int MouseEvent_RightDown = 0x0008;
        public const int MouseEvent_RightUp = 0x0010;
        public const int MouseEvent_Wheel = 0x0800;
        public const int MousseEvent_XUp = 0x0100;
        public const int MousseEvent_XDown = 0x0080;

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public Int32 dx;
            public Int32 dy;
            public Int32 Mousedata;
            public Int32 dwFlag;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct tagKEYBDINPUT
        {
            public Int16 wVk;
            public Int16 wScan;
            public Int32 dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct tagHARDWAREINPUT
        {
            Int32 uMsg;
            Int16 wParamL;
            Int16 wParamH;
        }


        [StructLayout(LayoutKind.Explicit)]
        public struct INPUT
        {
            [FieldOffset(0)]
            public Int32 type;
            [FieldOffset(4)]
            public MouseInput mi;
            [FieldOffset(4)]
            public tagKEYBDINPUT ki;
            [FieldOffset(4)]
            public tagHARDWAREINPUT hi;
        }


        [DllImport("user32.dll")]
        //public static extern UInt32 SendInput(UInt32 nInputs, INPUT[] pInputs, int cbSize);
        public static extern UInt32 SendInput(UInt32 nInputs, ref INPUT pInputs, int cbSize);

        public static void KeyDown(Int16 ScanCode1)
        {
            INPUT[] InputData = new INPUT[2];
            //Key ScanCode = Key.D;

            InputData[0].type = INPUT_KEYBOARD;
            InputData[0].ki.wScan = ScanCode1;
            InputData[0].ki.dwFlags = KEYEVENTF_SCANCODE;

            InputData[1].type = INPUT_KEYBOARD;
            InputData[1].ki.wScan = ScanCode1;
            InputData[1].ki.dwFlags = (KEYEVENTF_KEYUP | KEYEVENTF_SCANCODE);

            try
            {
                SendInput(1, ref InputData[0], Marshal.SizeOf(InputData[0]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(100);
            }
            catch
            {
                return;
            }
        }

        public static void ShiftKeyDown(Int16 ScanCode1)
        {
            INPUT[] InputData = new INPUT[4];
            //Key ScanCode = Key.D;

            InputData[0].type = INPUT_KEYBOARD;
            InputData[0].ki.wScan = ScanCode1;
            InputData[0].ki.dwFlags = KEYEVENTF_SCANCODE;

            InputData[1].type = INPUT_KEYBOARD;
            InputData[1].ki.wScan = ScanCode1;
            InputData[1].ki.dwFlags = (KEYEVENTF_KEYUP | KEYEVENTF_SCANCODE);

            InputData[2].type = INPUT_KEYBOARD;
            InputData[2].ki.wScan = 0x2a;//Left Shift 00 2A 
            InputData[2].ki.dwFlags = KEYEVENTF_SCANCODE;

            InputData[3].type = INPUT_KEYBOARD;
            InputData[3].ki.wScan = 0x2a;//Left Shift 00 2A
            InputData[3].ki.dwFlags = (KEYEVENTF_KEYUP | KEYEVENTF_SCANCODE);

            try
            {
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[2]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[0], Marshal.SizeOf(InputData[0]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[3], Marshal.SizeOf(InputData[3]));
                System.Threading.Thread.Sleep(100);
            }
            catch
            {
                return;
            }
        }
        
        public static void KeyDownd(Int16 ScanCode1)
        {
            INPUT[] InputData = new INPUT[1];
            //Key ScanCode = Key.D;

            InputData[0].type = INPUT_KEYBOARD;
            InputData[0].ki.wScan = ScanCode1;
            InputData[0].ki.dwFlags = KEYEVENTF_SCANCODE;

            try
            {
                SendInput(1, ref InputData[0], Marshal.SizeOf(InputData[0]));
                System.Threading.Thread.Sleep(100);
            }
            catch
            {
                return;
            }
        }

        public static void KeyDownu(Int16 ScanCode1)
        {
            INPUT[] InputData = new INPUT[1];
            //Key ScanCode = Key.D;

            InputData[0].type = INPUT_KEYBOARD;
            InputData[0].ki.wScan = ScanCode1;
            InputData[0].ki.dwFlags = (KEYEVENTF_KEYUP | KEYEVENTF_SCANCODE);
            
            try
            {
                SendInput(1, ref InputData[0], Marshal.SizeOf(InputData[0]));
                System.Threading.Thread.Sleep(100);
            }
            catch
            {
                return;
            }
        }

        public static void MouseMoveRightClick()
        {
            INPUT[] InputData = new INPUT[4];


            InputData[0].type = INPUT_MOUSE;
            InputData[0].mi.dx = 100;
            InputData[0].mi.dy = 100;
            InputData[0].mi.dwFlag = MouseEvent_Move;

            InputData[1].type = INPUT_MOUSE;
            InputData[1].mi.dx = 0;
            InputData[1].mi.dy = 0;
            InputData[1].mi.dwFlag = MouseEvent_RightDown;

            InputData[2].type = INPUT_MOUSE;
            InputData[2].mi.dx = 0;
            InputData[2].mi.dy = 0;
            InputData[2].mi.dwFlag = MouseEvent_RightUp;

            InputData[3].type = INPUT_MOUSE;
            InputData[3].mi.dx = -100;
            InputData[3].mi.dy = -100;
            InputData[3].mi.dwFlag = MouseEvent_Move;



            try
            {
                SendInput(1, ref InputData[0], Marshal.SizeOf(InputData[0]));
                System.Threading.Thread.Sleep(1500);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(500);
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(1500);
                SendInput(1, ref InputData[3], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(1500);
            }
            catch
            {
                return;
            }
        }

        public static void MouseRoll()
        {
            INPUT[] InputData = new INPUT[4];


            //    public Int32 dx;
            //public Int32 dy;
            //public Int32 Mousedata;
            //public Int32 dwFlag;
            //public const int MouseEvent_Absolute = 0x8000;
            //public const int MouserEvent_Hwheel = 0x01000;
            //public const int MouseEvent_Move = 0x0001;
            //public const int MouseEvent_Move_noCoalesce = 0x2000;
            //public const int MouseEvent_LeftDown = 0x0002;
            //public const int MouseEvent_LeftUp = 0x0004;
            //public const int MouseEvent_MiddleDown = 0x0020;
            //public const int MouseEvent_MiddleUp = 0x0040;
            //public const int MouseEvent_RightDown = 0x0008;
            //public const int MouseEvent_RightUp = 0x0010;
            //public const int MouseEvent_Wheel = 0x0800;
            //public const int MousseEvent_XUp = 0x0100;
            //public const int MousseEvent_XDown = 0x0080;

            InputData[0].type = INPUT_MOUSE;
            InputData[0].mi.dx = 100;
            InputData[0].mi.dy = 100;
            InputData[0].mi.Mousedata = 0;
            InputData[0].mi.dwFlag = MouseEvent_Move;

            InputData[1].type = INPUT_MOUSE;
            InputData[1].mi.dx = 0;
            InputData[1].mi.dy = 0;
            InputData[1].mi.Mousedata = 120;
            InputData[1].mi.dwFlag = MouseEvent_Wheel;

            InputData[2].type = INPUT_MOUSE;
            InputData[2].mi.dx = 0;
            InputData[2].mi.dy = 0;
            InputData[2].mi.Mousedata = -120;
            InputData[2].mi.dwFlag = MouseEvent_Wheel;

            InputData[3].type = INPUT_MOUSE;
            InputData[3].mi.dx = -100;
            InputData[3].mi.dy = -100;
            InputData[3].mi.Mousedata = 0;
            InputData[3].mi.dwFlag = MouseEvent_Move;



            try
            {
                SendInput(1, ref InputData[0], Marshal.SizeOf(InputData[0]));
                System.Threading.Thread.Sleep(1000);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[1], Marshal.SizeOf(InputData[1]));
                System.Threading.Thread.Sleep(2000);
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[2]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[2]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[2]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[2]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[2]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[2]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[2]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[2]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[2], Marshal.SizeOf(InputData[2]));
                System.Threading.Thread.Sleep(100);
                SendInput(1, ref InputData[3], Marshal.SizeOf(InputData[3]));
                System.Threading.Thread.Sleep(1000);
            }
            catch
            {
                return;
            }
        }

    }
}
