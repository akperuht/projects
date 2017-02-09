using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FastSerial
{
    /// <summary>
    /// Luokka päivittämään plottia taustalla omassa säikeessään
    /// </summary>
    class PlotUpdate
    {
        PlotModel model;
        LineSeries series;
        DataPoint point;
        bool updateneeded=false;

        /// <summary>
        /// Konstruktori jolle annetaan plotin päivittämiseen tarvittavat oliot
        /// </summary>
        /// <param name="model1"></param>
        /// <param name="series1"></param>
        public PlotUpdate(PlotModel model1, LineSeries series1)
        {
            this.model = model1;
            this.series = series1;
        }
        /// <summary>
        /// Annetaan plotin päivittyä
        /// </summary>
        /// <param name="point1"></param>
        public void Notify(DataPoint point1)
        {
            updateneeded = true;
            this.point = point1;
        }

        /// <summary>
        /// Threadin pyörittämä otus
        /// </summary>
        public void UpdatePlotter()
        {
            while (true) { Update(); }
        }
        /// <summary>
        /// Päivittää pisteen notify-komennosta
        /// </summary>
        private void Update()
        {
            if (updateneeded)
            {
                series.Points.Add(point);
                model.InvalidatePlot(true);
            }
            updateneeded = false;
        }
    }
}
