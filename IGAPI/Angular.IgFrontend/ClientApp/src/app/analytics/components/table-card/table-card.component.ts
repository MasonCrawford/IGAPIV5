import {Component, Input, OnInit} from '@angular/core';
import {Order} from "../../analytics.component";

@Component({
  selector: 'app-table-card',
  templateUrl: './table-card.component.html',
  styleUrls: ['./table-card.component.css']
})
export class TableCardComponent implements OnInit {
  @Input() label: string = "";
  @Input() color: string = "";
  @Input() Orders: Order[] = [];

  public from: string = "";
  public to: string = "";
  public border: string = "";
  public background: string = "";

  constructor() {
  }

  ngOnInit(): void {
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
      case "slate":
        this.border = "border-blue-500"
        this.background = "bg-slate-500"
        this.from = 'from-slate-200';
        this.to = 'to-slate-100';
        break;
    }
  }

}


