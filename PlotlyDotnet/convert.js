const fs = require('fs');

const plotlyLibStr = fs.readFileSync('./assets/plotly-v1.54.7.js', {encoding: 'utf-8'});
const plotlyLibBin = (new TextEncoder()).encode(plotlyLibStr);

const tempStr = fs.readFileSync('./index.html', {encoding: 'utf-8'});
const tempBin = (new TextEncoder()).encode(tempStr);

const temp = `\ufeffusing System;

namespace PlotlyDotnet
{
    public static class Assets
    {
        public static byte[] PlotlyLibBin = new byte[]{${plotlyLibBin}};
        public static byte[] TempBin = new byte[]{${tempBin}};
    }
}
`;

fs.writeFileSync('./Assets.cs', temp, {encoding: 'utf-8'});
