<template>
 <div class="q-pa-md">
    <div class="row justify-around">
    <div class="col-5 items-center text-center  bg-light-blue-1 text-indigo-9">
    <h4> Koraci za uspesno zakazane termine</h4>
    <apexchart width="600" type="bar" :options="options1" :series="series1"></apexchart>
    </div>
    <div class="col-5 items-center text-center  bg-light-blue-1 text-indigo-9">
      <h4> Procenat uspesnosti zakazivanja</h4>
    <apexchart type="pie" width="600" :options="chartOptionsSucess" :series="seriesSucess"></apexchart>
    </div>
    </div>
    <div class="text-center text-indigo-9" >
      <h4> Prosek ponavljanja svakog koraka</h4>
    <apexchart type="bar" height="350" :options="chartOptionsAvgSteps" :series="seriesAvgSteps"></apexchart>
    </div>
    <div class="row text-indigo-9 justify-center text-center">
    <div class="bg-light-blue-1">
    <h4> Uspesnost zakazivanja ako termin<br> nije pronadjen iz prvog puta</h4>
    <apexchart type="pie" width="600" :options="chartOptionsNT" :series="seriesNT"></apexchart>
    </div>
    </div>
</div>
</template>
<script>
export default {
  data: function () {
    return {
      arr: [],
      statisticDTO: {},
      options1: {
        chart: {
          id: 'vuechart-example'
        },
        xaxis: {
          categories: ['MIN', 'AVG', 'MAX']
        }
      },
      series1: [],
      seriesSucess: [],
      chartOptionsSucess: {
        chart: {
          width: 380,
          type: 'pie'
        },
        labels: ['Uspešno zakazano', 'Nije zakazano'],
        responsive: [{
          breakpoint: 480,
          options: {
            chart: {
              width: 200
            },
            legend: {
              position: 'bottom'
            }
          }
        }]
      },
      seriesNT: [],
      chartOptionsNT: {
        chart: {
          width: 380,
          type: 'pie'
        },
        labels: ['Uspešno zakazano', 'Nije zakazano'],
        responsive: [{
          breakpoint: 480,
          options: {
            chart: {
              width: 200
            },
            legend: {
              position: 'bottom'
            }
          }
        }]
      },
      series: [11, 11],
      chartOptions: {
        chart: {
          type: 'donut'
        },
        responsive: [{
          breakpoint: 480,
          options: {
            chart: {
              width: '200px'
            },
            legend: {
              position: 'bottom'
            }
          }
        }]
      },
      seriesAvgSteps: [],
      chartOptionsAvgSteps: {
        chart: {
          type: 'bar',
          height: 350
        },
        plotOptions: {
          bar: {
            horizontal: false,
            columnWidth: '55%',
            endingShape: 'rounded'
          }
        },
        dataLabels: {
          enabled: false
        },
        stroke: {
          show: true,
          width: 2,
          colors: ['transparent']
        },
        xaxis: {
          categories: ['Korak 1', 'Korak 2', 'Korak 3', 'Korak 4']
        },
        yaxis: {
          title: {
            text: 'AVG ponavljanja po koraku'
          }
        },
        fill: {
          opacity: 1
        },
        tooltip: {
          y: {
            formatter: function (val) {
              return val + ' puta u proseku'
            }
          }
        }
      }
    }
  },
  async beforeMount () {
    await this.$axios.get('https://localhost:44340/events')
      .then(response => {
        this.statisticDTO = response.data
      })
    var obj = {}
    var series1 = []
    series1.push(this.statisticDTO.min)
    series1.push(this.statisticDTO.avg)
    series1.push(this.statisticDTO.max)
    var name = 'Broj koraka'
    obj.name = name
    obj.data = series1
    this.series1.push(obj)
    this.seriesSucess.push(this.statisticDTO.success)
    this.seriesSucess.push(this.statisticDTO.allSesions - this.statisticDTO.success)
    this.seriesNT.push(this.statisticDTO.noTermScheduled)
    this.seriesNT.push(this.statisticDTO.noTermNotScheduled)
    var objAvg1 = {}
    var nameAvg1 = 'Sva zakazivanja'
    objAvg1.name = nameAvg1
    objAvg1.data = this.statisticDTO.avgStepCount
    this.seriesAvgSteps.push(objAvg1)
    var objAvg2 = {}
    var nameAvg2 = 'Uspesna zakazivanja'
    objAvg2.name = nameAvg2
    objAvg2.data = this.statisticDTO.avgStepCountSucess
    this.seriesAvgSteps.push(objAvg2)
    var objAvg3 = {}
    var nameAvg3 = 'Neuspesna zakazivanja'
    objAvg3.name = nameAvg3
    objAvg3.data = this.statisticDTO.avgStepCountNotSucess
    this.seriesAvgSteps.push(objAvg3)
  }
}
</script>
