/*   This file is part of ACS Viewer.

    ACS Viewer is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    ACS Viewer is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.ComponentModel;

namespace AcsLib
{
    public class Music
    {
        public enum MusicType : int
        { 
            [DescriptionAttribute("Nothing")]
            Nothing = -1,
            [DescriptionAttribute("SKITTER DOWN")]
            SkitterDown = 0,
            [DescriptionAttribute("WOOP WOOP")]
            WoopWoop = 1,
            [DescriptionAttribute("BLASTOFF")]
            Blastoff = 2,
            [DescriptionAttribute("BLIP")]
            Blip = 3,
            [DescriptionAttribute("RAZZ")]
            Razz = 4,
            [DescriptionAttribute("TAP")]
            Tap = 5,
            [DescriptionAttribute("KABLOOM")]
            Kabloom = 6,
            [DescriptionAttribute("BLOWIE")]
            Blowie = 7,
            [DescriptionAttribute("KABLOWIE")]
            Kablowie = 8,
            [DescriptionAttribute("TWEETER")]
            Tweeter = 9,
            [DescriptionAttribute("SKITTER UP")]
            SkitterUp = 10,
            [DescriptionAttribute("ZOOP ZOOP")]
            ZoopZoop = 11,
            [DescriptionAttribute("DUSK")]
            Dusk = 12,
            [DescriptionAttribute("ENDLESS FANTASY")]
            EndlessFantasy = 13,
            [DescriptionAttribute("ENDLESS SPY/MYSTERY")]
            EndlessSpyMystery = 14,
            [DescriptionAttribute("ENDLESS SCIFI")]
            EndlessSciFi = 15,
            [DescriptionAttribute("ENDLESS SUITE")]
            EndlessSuite = 16,
            [DescriptionAttribute("1 VOICE FUGUE")]
            Voice1Fugue = 17,
            [DescriptionAttribute("2 VOICE FUGUE")]
            Voice2Fugue = 18,
            [DescriptionAttribute("3 VOICE FUGUE")]
            Voice3Fugue = 19,
            [DescriptionAttribute("FUGUE FINALE")]
            FugueFinale = 20,
            [DescriptionAttribute("FANFARE")]
            Fanfare = 21,
            [DescriptionAttribute("HEROIC THEME")]
            HeroicTheme = 22,
            [DescriptionAttribute("DEPARTURE")]
            Departure = 23,
            [DescriptionAttribute("TRAVELING")]
            Traveling = 24,
            [DescriptionAttribute("BATTLE")]
            Battle = 25,
            [DescriptionAttribute("DEATH BLOW")]
            DeathBlow = 26,
            [DescriptionAttribute("DIRGE")]
            Dirge = 27,
            [DescriptionAttribute("RETURN")]
            Return = 28,
            [DescriptionAttribute("CLOSE")]
            Close = 29,
            // the following sounds are specific to the Amiga version of ACS:
            [DescriptionAttribute("PLUMMET")]
            Plummet = 30,
            [DescriptionAttribute("GONG")]
            Gong = 31,
            [DescriptionAttribute("ROAR")]
            Roar = 32,
            [DescriptionAttribute("GROWL")]
            Growl = 33,
            [DescriptionAttribute("EAGLE SHRIEK")]
            EagleShriek = 34,
            [DescriptionAttribute("BONE BITE")]
            BoneBite = 35,
            [DescriptionAttribute("POP")]
            Pop = 36,
            [DescriptionAttribute("DOINK")]
            Doink = 37,
            [DescriptionAttribute("SPLOT")]
            Splot = 38,
            [DescriptionAttribute("DOING DOING")]
            DoingDoing = 39,
            [DescriptionAttribute("C R A Z Y")]
            CRAZY = 40
        }

        public MusicType TypeOfMusic { get; set; }

        public string MusicTypeDescription
        {
            get { return TypeOfMusic.ToDescription(); }
        }

        public Music()
        {
            TypeOfMusic = MusicType.Nothing;
        }

        public string GetMusicName(int m)
        {
            TypeOfMusic = (MusicType)m;
            return TypeOfMusic.ToDescription();
        }

    }
}
