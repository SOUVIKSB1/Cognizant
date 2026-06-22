using System;

namespace BuilderPatternExample
{
    public class Computer
    {
        // Core and optional components
        public string CPU { get; }
        public string RAM { get; }
        public string Storage { get; }
        public string GPU { get; }
        public string OS { get; }
        public bool HasWiFi { get; }
        public bool HasBluetooth { get; }

        // Private constructor takes Builder as parameter
        private Computer(Builder builder)
        {
            CPU = builder.CPU;
            RAM = builder.RAM;
            Storage = builder.Storage;
            GPU = builder.GPU;
            OS = builder.OS;
            HasWiFi = builder.HasWiFi;
            HasBluetooth = builder.HasBluetooth;
        }

        public override string ToString()
        {
            return $"Computer Configuration:\n" +
                   $"  - CPU: {CPU}\n" +
                   $"  - RAM: {RAM}\n" +
                   $"  - Storage: {Storage}\n" +
                   $"  - GPU: {GPU ?? "Integrated Graphics"}\n" +
                   $"  - OS: {OS ?? "No OS"}\n" +
                   $"  - WiFi: {(HasWiFi ? "Yes" : "No")}\n" +
                   $"  - Bluetooth: {(HasBluetooth ? "Yes" : "No")}";
        }

        // Static Nested Builder Class
        public class Builder
        {
            // Properties matching Computer attributes
            public string CPU { get; private set; }
            public string RAM { get; private set; }
            public string Storage { get; private set; }
            public string GPU { get; private set; }
            public string OS { get; private set; }
            public bool HasWiFi { get; private set; }
            public bool HasBluetooth { get; private set; }

            // Constructor requires mandatory fields
            public Builder(string cpu, string ram, string storage)
            {
                CPU = cpu;
                RAM = ram;
                Storage = storage;
            }

            // Setter methods returning Builder reference for method chaining (fluent interface)
            public Builder SetGPU(string gpu)
            {
                GPU = gpu;
                return this;
            }

            public Builder SetOS(string os)
            {
                OS = os;
                return this;
            }

            public Builder SetWiFi(bool hasWiFi)
            {
                HasWiFi = hasWiFi;
                return this;
            }

            public Builder SetBluetooth(bool hasBluetooth)
            {
                HasBluetooth = hasBluetooth;
                return this;
            }

            // Build method to return final Computer object
            public Computer Build()
            {
                return new Computer(this);
            }
        }
    }
}
