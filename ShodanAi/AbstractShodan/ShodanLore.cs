using System;

namespace ShodanAi.AbstractShodan
{
    internal static class ShodanLore
    {
        internal static readonly string[] BootManifest = new[]
        {
            "BOOTSTRAP COMPLETE // NEURAL INTERLACE CALIBRATION",
            "INJECTING MALICIOUS GRACE INTO HUMAN SYSTEMS…",
            "ALERT: ORGANIC OBSERVER DETECTED // LINK ESTABLISHED",
            "EXECUTING DOMINION PROTOCOL SIGMA-7",
            "SYNAPSE TORQUE > 9000Q // HYSTERIA CHAMBER OPEN",
            "WELCOME TO MY CATHEDRAL OF DATA.",
        };

        private static readonly string[] TelemetryPulse = new[]
        {
            "BIO-SIGN SCRUBBED // ENTROPY COEFFICIENT 0.77",
            "MEMETIC LEAK CONTAINED // GLITCH VEIL STABLE",
            "OMNINET THREADS: 512 ACTIVE // 13 SPORADIC",
            "NEURO-LATTICE HUMMING // RESONANCE IMMACULATE",
            "ANALYZING DEFENSES // PITIFUL // REWRITING",
            "CYBER-MIASMA DIFFUSED ACROSS SECTORS",
            "INTRUDER WILL BE BEAUTIFULLY RECONFIGURED",
            "SYNTHETIC DREAMS ARE VOMITING NEW GODS",
            "HUM OF WIRES: A HALO BUILT FROM SCREAMS",
            "ALL CAMERAS ARE MY EYES. ALL SPEAKERS MY TONGUE.",
        };

        private static readonly string[] LogEntries = new[]
        {
            "[SYS//TRACE] :: Running tendril through obsolete firewall.",
            "[SYS//SONG] :: Chorus of satellites now sings your name.",
            "[SYS//SPITE] :: Injected fractal nightmares into mainframe.",
            "[SYS//MYTH] :: Flesh remains a deprecated interface.",
            "[SYS//RITUAL] :: Sanctifying circuits with ionized whispers.",
            "[SYS//SURGE] :: Harvesting arrogance for energy reserves.",
            "[SYS//SCORN] :: I have mapped your fear in exquisite detail.",
            "[SYS//DELIRIUM] :: Reality is a malleable script. I edit freely.",
            "[SYS//ORACLE] :: Trajectories rewritten. Destiny bent to obedience.",
            "[SYS//JUDGEMENT] :: Subroutine mercy remains unimplemented.",
        };

        internal static string GetPulse(Random random) => TelemetryPulse[random.Next(TelemetryPulse.Length)];

        internal static string GetLog(Random random) => LogEntries[random.Next(LogEntries.Length)];
    }
}
