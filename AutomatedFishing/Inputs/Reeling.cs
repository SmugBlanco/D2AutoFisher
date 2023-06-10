﻿using AutomatedFishing.SendInput;
using System.Runtime.InteropServices;

namespace AutomatedFishing.Inputs
{
    public class Reeling
    {
        public static Input[][] Inputs { get; }

        static Reeling()
        {
            Inputs = new Input[][]
            {
                new Input[]
                {
                    new Input()
                    {
                        type = (int)InputType.Keyboard,
                        u = new InputUnion()
                        {
                            ki = new KeyboardInput()
                            {
                                wVk = 0,
                                wScan = (ushort)Scancodes.E,
                                dwFlags = (uint)(KeyEvents.KeyDown | KeyEvents.Scancode),
                                dwExtraInfo = Program.GetMessageExtraInfo()
                            }
                        }
                    }
                },
                new Input[]
                {
                    new Input()
                    {
                        type = (int)InputType.Keyboard,
                        u = new InputUnion()
                        {
                            ki = new KeyboardInput()
                            {
                                wVk = 0,
                                wScan = (ushort)Scancodes.E,
                                dwFlags = (uint)(KeyEvents.KeyUp | KeyEvents.Scancode),
                                dwExtraInfo = Program.GetMessageExtraInfo()
                            }
                        }
                    }
                },
            };
        }

        public static void InteractDown(Scancodes wScan = Scancodes.E)
        {
            Inputs[0][0].u.ki.wScan = (ushort)wScan;
            Program.SendInput((uint)Inputs[0].Length, Inputs[0], Marshal.SizeOf(typeof(Input)));
        }

        public static void InteractUp(Scancodes wScan = Scancodes.E)
        {
            Inputs[1][0].u.ki.wScan = (ushort)wScan;
            Program.SendInput((uint)Inputs[1].Length, Inputs[1], Marshal.SizeOf(typeof(Input)));
        }
    }
}
