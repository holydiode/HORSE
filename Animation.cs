using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HORSE
{
    class Animation
    {
        private List<Texture> textures;
        private int frameCount;
        private int endFrame;
        private int frameByTexture;
        private delegate Coord2d rePosition(Coord2d now, int frame);
        bool loop;
    }
}
