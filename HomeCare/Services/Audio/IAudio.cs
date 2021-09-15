using System;
using System.Collections.Generic;
using System.Text;

namespace HomeCare.Services.Audio
{
    public interface IAudio
    {
        bool PlayWavSuccess();

        bool PlayWavError();
    }

}
