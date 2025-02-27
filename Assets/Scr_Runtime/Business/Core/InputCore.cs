using System;
using UnityEngine;
using HNY;
using UnityEngine.InputSystem;

public class InputCore
{
    public bool getKeyDown;

    public int noteNumber;

    public int GetKey()
    {
        //onDeviceChange 输入设备变化触发事件
        InputSystem.onDeviceChange += (device, change) =>
        {
            // //Added 添加新设备
            // if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            midiDevice.onWillNoteOn += (note, velocity) => {
                Debug.Log(string.Format(
                    "Note On #{0} ({1}) vel:{2:0.00} ch:{3} dev:'{4}'",
                    note.noteNumber,
                    note.shortDisplayName,
                    velocity,
                    (note.device as Minis.MidiDevice)?.channel,
                    note.device.description.product
                ));
                
                getKeyDown = true;
                noteNumber = note.noteNumber;
            };

            midiDevice.onWillNoteOff += (note) => {
                // Debug.Log(string.Format(
                //     "Note Off #{0} ({1}) ch:{2} dev:'{3}'",
                //     note.noteNumber,
                //     note.shortDisplayName,
                //     (note.device as Minis.MidiDevice)?.channel,
                //      note.device.description.product
                // ));

                getKeyDown = false;
            };
        };

        return noteNumber;
    }
}