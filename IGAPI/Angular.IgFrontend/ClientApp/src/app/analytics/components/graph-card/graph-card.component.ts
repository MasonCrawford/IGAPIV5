import {Component, Input, OnInit} from '@angular/core';
import {ChartConfiguration, ChartType} from 'chart.js';

@Component({
  selector: 'app-graph-card',
  templateUrl: './graph-card.component.html',
  styleUrls: ['./graph-card.component.css']
})
export class GraphCardComponent implements OnInit {
  @Input() values: number[] = [];
  @Input() labels: string[] = [];
  @Input() label: string = "";

  public current: number = 0;
  public percent: number = 0;

  public lineChartData: ChartConfiguration['data'] = {
    datasets: [
      {
        data: this.values,
        label: 'Series A',
        backgroundColor: 'rgba(52,152,219,0.56)',
        borderColor: 'rgba(136,136,136,0.5)',
        pointBackgroundColor: '#3498db',
        pointBorderColor: '#fff',
        fill: 'origin',
      },
      // {
      //   data: [ 28, 48, 40, 19, 86, 27, 90 ],
      //   label: 'Series B',
      //   backgroundColor: 'rgba(77,83,96,0.2)',
      //   borderColor: 'rgba(77,83,96,1)',
      //   pointBackgroundColor: 'rgba(77,83,96,1)',
      //   pointBorderColor: '#fff',
      //   pointHoverBackgroundColor: '#fff',
      //   pointHoverBorderColor: 'rgba(77,83,96,1)',
      //   fill: 'origin',
      // },
      // {
      //   data: [ 180, 480, 770, 90, 1000, 270, 400 ],
      //   label: 'Series C',
      //   yAxisID: 'y-axis-1',
      //   backgroundColor: 'rgba(255,0,0,0.3)',
      //   borderColor: 'red',
      //   pointBackgroundColor: 'rgba(148,159,177,1)',
      //   pointBorderColor: '#fff',
      //   pointHoverBackgroundColor: '#fff',
      //   pointHoverBorderColor: 'rgba(148,159,177,0.8)',
      //   fill: 'origin',
      // }
    ],
    labels: this.labels
  };

  public lineChartOptions: ChartConfiguration['options'] = {
    elements: {
      line: {
        tension: 0.01
      },
    },
    plugins: {
      legend: {
        display: false
      },
    },
    layout: {
      padding: 0,
    },
    scales: {
      // We use this empty structure as a placeholder for dynamic theming.
      x: {},
      'y-axis-1': {
        position: 'right',
        ticks: {
          color: 'black'
        }
      }
    }
  };

  public lineChartType: ChartType = 'line';


  constructor() {


  }

  ngOnInit(): void {

    console.log(this.values[0])
    console.log(this.values[this.values.length - 1])

    this.current = this.values[0];
    let StartingValue = this.values[this.values.length - 1];
    this.percent = ((StartingValue - this.current) / this.current)

    console.log(this.percent)

    this.lineChartData = {
      datasets: [
        {
          data: this.values,
          label: this.label,
          backgroundColor: 'rgba(52,152,219,0.5)',
          borderColor: 'rgba(136,136,136,0.5)',
          pointBackgroundColor: '#3498db',
          pointBorderColor: '#fff',
          fill: 'origin',
        },
        // {
        //   data: [ 28, 48, 40, 19, 86, 27, 90 ],
        //   label: 'Series B',
        //   backgroundColor: 'rgba(77,83,96,0.2)',
        //   borderColor: 'rgba(77,83,96,1)',
        //   pointBackgroundColor: 'rgba(77,83,96,1)',
        //   pointBorderColor: '#fff',
        //   pointHoverBackgroundColor: '#fff',
        //   pointHoverBorderColor: 'rgba(77,83,96,1)',
        //   fill: 'origin',
        // },
        // {
        //   data: [ 180, 480, 770, 90, 1000, 270, 400 ],
        //   label: 'Series C',
        //   yAxisID: 'y-axis-1',
        //   backgroundColor: 'rgba(255,0,0,0.3)',
        //   borderColor: 'red',
        //   pointBackgroundColor: 'rgba(148,159,177,1)',
        //   pointBorderColor: '#fff',
        //   pointHoverBackgroundColor: '#fff',
        //   pointHoverBorderColor: 'rgba(148,159,177,0.8)',
        //   fill: 'origin',
        // }
      ],
      labels: this.labels
    }
  }

}
