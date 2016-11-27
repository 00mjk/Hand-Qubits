﻿using System;
using System.Threading;
using System.Windows;
using System.Windows.Media.Media3D;
using InTheHand.Net;

namespace QubitServer {
    public partial class MainWindow : Window {
        private QubitMotionTracker qubit1;
        private QubitMotionTracker qubit2;

        public MainWindow() {
            InitializeComponent();

            qubit1 = new QubitMotionTracker(
                new BluetoothAddress(new byte[] { 0xBC, 0x53, 0x70, 0x32, 0xD3, 0x98, 0, 0 }),
                new MotionDestGraph(motionChart1),
                q => poseTransform.Rotation = new QuaternionRotation3D(q),
                new Quaternion(new Vector3D(0, 1, 0), -90) * new Quaternion(new Vector3D(0, 1, 0), 10),
                new Quaternion(new Vector3D(1, 0, 0), 90),
                new Quaternion(new Vector3D(0, 0, 1), -45));

            qubit2 = new QubitMotionTracker(
                new BluetoothAddress(new byte[] { 0x9D, 0x53, 0x90, 0x34, 0xD3, 0x98, 0, 0 }),
                new MotionDestGraph(motionChart2),
                q => poseTransform2.Rotation = new QuaternionRotation3D(q),
                new Quaternion(new Vector3D(0, 1, 0), -5),
                new Quaternion(new Vector3D(1, 0, 0), 90),
                new Quaternion(new Vector3D(0, 0, 1), -45));

            runForever(new MotionSourceBluetooth(qubit1.address), qubit1.advanceSimulation);
            runForever(new MotionSourceBluetooth(qubit2.address), qubit2.advanceSimulation);
        }

        private void runForever(MotionSource src, Action<MotionSourceReading> dst) {
            ThreadPool.QueueUserWorkItem(_ => Util.RetryForever(() => {
                src.init();

                while (true) {
                    var reading = src.nextReading();
                    Application.Current.Dispatcher.Invoke(() => dst(reading));
                }
            }));
        }

        private void button_Click(object sender, RoutedEventArgs e) {
            qubit1.reset();
            qubit2.reset();
        }
    }
}
