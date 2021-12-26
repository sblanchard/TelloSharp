﻿using System.Text;
using static TelloSharp.Messages;

namespace TelloSharp
{
    public partial class Tello
    {
        public class FlyData
        {
            private int flyMode;
            private int height;
            private int verticalSpeed;
            private int flySpeed;
            private int eastSpeed;
            private int northSpeed;
            private int flyTime;
            private bool flying;

            private bool downVisualState;
            private bool droneHover;
            private bool eMOpen;
            private bool onGround;
            private bool pressureState;

            private bool batteryCritical;
            private int batteryPercentage;
            private bool batteryLow;
            private bool batteryLower;
            private bool batteryState;
            private bool powerState;
            private int droneBatteryLeft;
            private int droneFlyTimeLeft;

            private int cameraState;
            private int electricalMachineryState;
            private bool factoryMode;
            private bool frontIn;
            private bool frontLSC;
            private bool frontOut;
            private bool gravityState;
            private int imuCalibrationState;
            private bool imuState;
            private int lightStrength;
            private bool outageRecording;
            private int smartVideoExitMode;
            private int temperatureHeight;
            private int throwFlyTimer;
            private int wifiDisturb;
            private byte wifiStrength;
            private bool windState;

            private float velX;
            private float velY;
            private float velZ;

            private float posX;
            private float posY;
            private float posZ;
            private float posUncertainty;

            private float velN;
            private float velE;
            public float velD;

            private float quatX;
            private float quatY;
            private float quatZ;
            private float quatW;
            private DateTime lightStrengthUpdated;
            private readonly Tello tello;

            public int FlyMode { get => flyMode; set => flyMode = value; }
            public int Height { get => height; set => height = value; }
            public int VerticalSpeed { get => verticalSpeed; set => verticalSpeed = value; }
            public int FlySpeed { get => flySpeed; set => flySpeed = value; }
            public int EastSpeed { get => eastSpeed; set => eastSpeed = value; }
            public int NorthSpeed { get => northSpeed; set => northSpeed = value; }
            public int FlyTime { get => flyTime; set => flyTime = value; }
            public bool Flying { get => flying; set => flying = value; }
            public bool DownVisualState { get => downVisualState; set => downVisualState = value; }
            public bool DroneHover { get => droneHover; set => droneHover = value; }
            public bool EMOpen { get => eMOpen; set => eMOpen = value; }
            public bool OnGround { get => onGround; set => onGround = value; }
            public bool PressureState { get => pressureState; set => pressureState = value; }
            public int BatteryPercentage { get => batteryPercentage; set => batteryPercentage = value; }
            public bool BatteryLow { get => batteryLow; set => batteryLow = value; }
            public bool BatteryLower { get => batteryLower; set => batteryLower = value; }
            public bool BatteryState { get => batteryState; set => batteryState = value; }
            public bool PowerState { get => powerState; set => powerState = value; }
            public int DroneBatteryLeft { get => droneBatteryLeft; set => droneBatteryLeft = value; }
            public int DroneFlyTimeLeft { get => droneFlyTimeLeft; set => droneFlyTimeLeft = value; }
            public int CameraState { get => cameraState; set => cameraState = value; }
            public int ElectricalMachineryState { get => electricalMachineryState; set => electricalMachineryState = value; }
            public bool FactoryMode { get => factoryMode; set => factoryMode = value; }
            public bool FrontIn { get => frontIn; set => frontIn = value; }
            public bool FrontLSC { get => frontLSC; set => frontLSC = value; }
            public bool FrontOut { get => frontOut; set => frontOut = value; }
            public bool GravityState { get => gravityState; set => gravityState = value; }
            public int ImuCalibrationState { get => imuCalibrationState; set => imuCalibrationState = value; }
            public bool ImuState { get => imuState; set => imuState = value; }
            public int LightStrength { get => lightStrength; set => lightStrength = value; }
            public DateTime LightStrengthUpdated { get => lightStrengthUpdated; set => lightStrengthUpdated = value; }
            public bool OutageRecording { get => outageRecording; set => outageRecording = value; }
            public int SmartVideoExitMode { get => smartVideoExitMode; set => smartVideoExitMode = value; }
            public int TemperatureHeight { get => temperatureHeight; set => temperatureHeight = value; }
            public int ThrowFlyTimer { get => throwFlyTimer; set => throwFlyTimer = value; }
            public int WifiDisturb { get => wifiDisturb; set => wifiDisturb = value; }
            public byte WifiStrength { get => wifiStrength; set => wifiStrength = value; }
            public byte WifiInterference { get; internal set; }
            public bool WindState { get => windState; set => windState = value; }
            public float VelX { get => velX; set => velX = value; }
            public float VelY { get => velY; set => velY = value; }
            public float VelZ { get => velZ; set => velZ = value; }
            public float PosX { get => posX; set => posX = value; }
            public float PosY { get => posY; set => posY = value; }
            public float PosZ { get => posZ; set => posZ = value; }
            public float PosUncertainty { get => posUncertainty; set => posUncertainty = value; }
            public float VelN { get => velN; set => velN = value; }
            public float VelE { get => velE; set => velE = value; }
            public float QuatX { get => quatX; set => quatX = value; }
            public float QuatY { get => quatY; set => quatY = value; }
            public float QuatZ { get => quatZ; set => quatZ = value; }
            public float QuatW { get => quatW; set => quatW = value; }
            public bool BatteryCritical { get => batteryCritical; set => batteryCritical = value; }
            public byte MaxHeight { get; internal set; }
            public byte LowBatteryThreshold { get; internal set; }
            public string? SSID { get; internal set; }
            public string? Version { get; internal set; }

            public Messages.VBR VideoBitrate { get; set; }
            public Messages.MVOData MVO;
            public Messages.IMUData IMU;

            public FlyData(Tello tello)
            {
                this.tello = tello;
                MVO = new Messages.MVOData();
                IMU = new Messages.IMUData();
            }

            public void Set(byte[] data)
            {
                int index = 0;
                height = (short)(data[index] | (data[index + 1] << 8)); index += 2;
                northSpeed = (short)(data[index] | (data[index + 1] << 8)); index += 2;
                eastSpeed = (short)(data[index] | (data[index + 1] << 8)); index += 2;
                FlySpeed = ((int)Math.Sqrt(Math.Pow(northSpeed, 2.0D) + Math.Pow(eastSpeed, 2.0D)));
                verticalSpeed = (short)(data[index] | (data[index + 1] << 8)); index += 2;
                flyTime = data[index] | (data[index + 1] << 8); index += 2;

                imuState = (data[index] >> 0 & 0x1) == 1;
                pressureState = (data[index] >> 1 & 0x1) == 1;
                downVisualState = (data[index] >> 2 & 0x1) == 1;
                powerState = (data[index] >> 3 & 0x1) == 1;
                batteryState = (data[index] >> 4 & 0x1) == 1;
                gravityState = (data[index] >> 5 & 0x1) == 1;
                windState = (data[index] >> 7 & 0x1) == 1;
                index += 1;

                imuCalibrationState = data[index]; index += 1;
                batteryPercentage = data[index]; index += 1;
                droneFlyTimeLeft = data[index] | (data[index + 1] << 8); index += 2;
                droneBatteryLeft = data[index] | (data[index + 1] << 8); index += 2;

                //index 17
                flying = (data[index] >> 0 & 0x1) == 1;
                onGround = (data[index] >> 1 & 0x1) == 1;
                eMOpen = (data[index] >> 2 & 0x1) == 1;
                droneHover = (data[index] >> 3 & 0x1) == 1;
                outageRecording = (data[index] >> 4 & 0x1) == 1;
                batteryLow = (data[index] >> 5 & 0x1) == 1;
                batteryLower = (data[index] >> 6 & 0x1) == 1;
                factoryMode = (data[index] >> 7 & 0x1) == 1;
                index += 1;

                FlyMode = data[index]; index += 1;
                throwFlyTimer = data[index]; index += 1;
                cameraState = data[index]; index += 1;

                electricalMachineryState = data[index]; index += 1;

                frontIn = (data[index] >> 0 & 0x1) == 1;
                frontOut = (data[index] >> 1 & 0x1) == 1;
                frontLSC = (data[index] >> 2 & 0x1) == 1;
                index += 1;
                temperatureHeight = (data[index] >> 0 & 0x1);//23            
                wifiStrength = tello._wifiStrength;//Wifi str comes in a cmd.
            }

            public void ParseLog(byte[] data)
            {
                int pos = 0;

                while (pos < data.Length - 2)//-2 for CRC bytes at end of packet.
                {
                    if (data[pos] != (byte)'U')
                    {
                        break;
                    }
                    byte len = data[pos + 1];
                    if (data[pos + 2] != 0)
                    {
                        break;
                    }

                    ushort id = BitConverter.ToUInt16(data, pos + 4);
                    byte[]? xorBuf = new byte[256];
                    byte xorValue = data[pos + 6];
                    switch (id)
                    {
                        case (ushort)LogRecTypes.logRecNewMVO:
                            for (int i = 0; i < len; i++)
                            {
                                xorBuf[i] = (byte)(data[pos + i] ^ xorValue);
                            }

                            int index = 10;
                            velX = BitConverter.ToInt16(xorBuf, index); index += 2;
                            velY = BitConverter.ToInt16(xorBuf, index); index += 2;
                            velZ = BitConverter.ToInt16(xorBuf, index); index += 2;
                            posX = BitConverter.ToSingle(xorBuf, index); index += 4;
                            posY = BitConverter.ToSingle(xorBuf, index); index += 4;
                            posZ = BitConverter.ToSingle(xorBuf, index); index += 4;
                            posUncertainty = BitConverter.ToSingle(xorBuf, index) * 10000.0f; index += 4;
                            break;
                        case (ushort)LogRecTypes.logRecIMU:
                            for (int i = 0; i < len; i++)
                            {
                                xorBuf[i] = (byte)(data[pos + i] ^ xorValue);
                            }

                            int index2 = 10 + 48;//44 is the start of the quat data.
                            quatW = BitConverter.ToSingle(xorBuf, index2); index2 += 4;
                            quatX = BitConverter.ToSingle(xorBuf, index2); index2 += 4;
                            quatY = BitConverter.ToSingle(xorBuf, index2); index2 += 4;
                            quatZ = BitConverter.ToSingle(xorBuf, index2);
                            index2 = 10 + 76;//Start of relative velocity
                            velN = BitConverter.ToSingle(xorBuf, index2); index2 += 4;
                            velE = BitConverter.ToSingle(xorBuf, index2); index2 += 4;
                            velD = BitConverter.ToSingle(xorBuf, index2);
                            break;

                    }
                    pos += len;
                }
            }

            public double[] ToEuler()
            {
                float qX = quatX;
                float qY = quatY;
                float qZ = quatZ;
                float qW = quatW;

                double sqW = qW * qW;
                double sqX = qX * qX;
                double sqY = qY * qY;
                double sqZ = qZ * qZ;
                double yaw = 0.0;
                double roll = 0.0;
                double pitch = 0.0;
                double[] retv = new double[3];
                double unit = sqX + sqY + sqZ + sqW; // if normalised is one, otherwise
                                                     // is correction factor
                double test = qW * qX + qY * qZ;
                if (test > 0.499 * unit)
                {
                    // singularity at north pole
                    yaw = 2 * Math.Atan2(qY, qW);
                    pitch = Math.PI / 2;
                    roll = 0;
                }
                else if (test < -0.499 * unit)
                {
                    // singularity at south pole
                    yaw = -2 * Math.Atan2(qY, qW);
                    pitch = -Math.PI / 2;
                    roll = 0;
                }
                else
                {
                    yaw = Math.Atan2(2.0 * (qW * qZ - qX * qY), 1.0 - 2.0 * (sqZ + sqX));
                    roll = Math.Asin(2.0 * test / unit);
                    pitch = Math.Atan2(2.0 * (qW * qY - qX * qZ), 1.0 - 2.0 * (sqY + sqX));
                }

                retv[0] = pitch;
                retv[1] = roll;
                retv[2] = yaw;
                return retv;
            }

            public string GetLogHeader()
            {
                StringBuilder sb = new StringBuilder();
                foreach (System.Reflection.FieldInfo property in GetType().GetFields())
                {
                    sb.Append(property.Name);
                    sb.Append(",");
                }
                sb.AppendLine();
                return sb.ToString();
            }

            public string GetLogLine()
            {
                StringBuilder sb = new StringBuilder();
                foreach (System.Reflection.FieldInfo property in GetType().GetFields())
                {
                    if (property.FieldType == typeof(bool))
                    {
                        if (!(bool)property.GetValue(this))
                        {
                            sb.Append("0");
                        }
                        else
                        {
                            sb.Append("1");
                        }
                    }
                    else
                    {
                        sb.Append(property.GetValue(this));
                    }

                    sb.Append(",");
                }
                sb.AppendLine();
                return sb.ToString();
            }

            public override string ToString()
            {
                StringBuilder sb = new();
                int count = 0;
                foreach (System.Reflection.PropertyInfo property in GetType().GetProperties())
                {
                    sb.Append(property.Name);
                    sb.Append(": ");
                    sb.Append(property.GetValue(this));
                    if (count++ % 2 == 1)
                    {
                        sb.Append(Environment.NewLine);
                    }
                    else
                    {
                        sb.Append("      ");
                    }
                }

                return sb.ToString();
            }
        }
    }
}