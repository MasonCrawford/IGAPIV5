import {Component, EventEmitter, Input, Output} from '@angular/core';
import {TradingtargetNames} from "../../../analytics/analytics.component";

@Component({
  selector: 'page-layout',
  templateUrl: './page-layout.component.html',
  styleUrls: ['./page-layout.component.css']
})
export class PageLayoutComponent {

  @Input() title: string = "";
  @Input() targets: TradingtargetNames[] | null = null;
  @Output() selectedOut = new EventEmitter<string>();
  public selected: string = "";

  constructor() {
  }

  valueChanged(newObj:string) {
    this.selectedOut.emit(newObj);
  }

}
