import {Component, Input, OnChanges, SimpleChanges} from '@angular/core';

@Component({
  selector: 'app-metric-card',
  templateUrl: './metric-card.component.html',
  styleUrls: ['./metric-card.component.css']
})
export class MetricCardComponent implements OnChanges {

  @Input() label: string = "";
  @Input() value: string = "";
  @Input() color: string = "";
  @Input() icon: string = "";
  public from: string = "";
  public to: string = "";
  public border: string = "";
  public background: string = "";

  constructor() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    switch (this.color) {
      case "green":
        this.border = "border-green-500"
        this.background = "bg-green-500"
        this.from = 'from-green-200';
        this.to = 'to-green-100';
        break;
      case "red":
        this.border = "border-red-500"
        this.background = "bg-red-500"
        this.from = 'from-red-200';
        this.to = 'to-red-100';
        break;
      case "yellow":
        this.border = "border-yellow-500"
        this.background = "bg-yellow-500"
        this.from = 'from-yellow-200';
        this.to = 'to-yellow-100';
        break;
      case "pink":
        this.border = "border-pink-500"
        this.background = "bg-pink-500"
        this.from = 'from-pink-200';
        this.to = 'to-pink-100';
        break;
    }
  }


}
