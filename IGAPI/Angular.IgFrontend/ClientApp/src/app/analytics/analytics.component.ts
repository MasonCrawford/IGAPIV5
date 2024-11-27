import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-analytics',
  templateUrl: './analytics.component.html',
  styleUrls: ['./analytics.component.css']
})
export class AnalyticsComponent implements OnInit {
  public chart1: number[] = []
  public chart1l: string[] = [];
  public chart2: number[] = []
  public chart2l: string[] = [];

  public totalProfitIcon: string = 'Minus';
  public totalProfitIconBg: string = 'text-Amber-500';

  public OrdersDetails: OrdersDetail = new class implements OrdersDetail {
    maxDeposit: number | null = null;
    minDeposit: number | null = null;
    totalProfit: number | null = null;
    tradeCount: number | null = null;
    winLossRate: number | null = null;
    totalProfitTrend: trend = trend.Minus;
  };

  public initialDeposit: number = 0;
  public selectedtradingtargetId: string | null = null;
  public Orders: Order[] = [];
  public tradingtargetNames: TradingtargetNames[] | null = null;

  constructor(readonly http: HttpClient, @Inject('BASE_URL') readonly baseUrl: string) {
    http.get<TradingtargetNames[]>(baseUrl + 'api/tradingtarget/names').subscribe(result => {
      this.tradingtargetNames = result;
    }, error => console.error(error));

  }

  public get(id: string) {
    this.getOrders(id)
    this.getOrdersDetails(id)
  }

  public getOrders(id: string) {
    this.http.get<Order[]>(this.baseUrl + 'api/tradingtarget/orders/' + id).subscribe(result => {
      this.Orders = result;
      console.log("result",result)
      this.Orders.map((o) => o.profit).forEach(p => {
          this.chart1.push(this.chart1[this.chart1.length - 1] == null ? p : this.chart1[this.chart1.length - 1] + p);
          this.chart1l.push(`${this.chart1.length}`);
      });
      this.Orders.map(o=>o.deposit).forEach(d=> {
        this.chart2.push(d);
        this.chart2l.push(`${this.chart2.length}`);
      })
    }, error => console.error(error));
  }

  public getOrdersDetails(id: string) {
    this.http.get<OrdersDetail>(this.baseUrl + 'api/tradingtarget/orders/details/' + id).subscribe(result => {
      this.OrdersDetails = result;

      function trendToBg(totalProfitTrend: trend) {
        let result: string = "";
        switch (totalProfitTrend) {
          case trend.Up:
            result = "text-green-500"
            break;
          case trend.Down:
            result = "text-red-500"
            break;
          case trend.Minus:
            result = "text-yellow-500"
            break;
        }
        return result;
      }

      function trendToIcon(totalProfitTrend: trend) {
        let result: string = "";
        switch (totalProfitTrend) {
          case trend.Up:
            result = "fa-caret-up"
            break;
          case trend.Down:
            result = "fa-caret-down"
            break;
          case trend.Minus:
            result = "fa-minus"
            break;
        }
        return result;
      }

      this.totalProfitIcon = trendToIcon(result.totalProfitTrend);
      this.totalProfitIconBg = trendToBg(result.totalProfitTrend);
    }, error => console.error(error));
  }

  ngOnInit(): void {

  }

}

export interface Order {
  orderId: string;
  accepted: boolean;
  contractSize: number;
  deposit: number;
  riskAmount: number;
  targetAmount: number;
  transactionReference: string;
  profit: number;
  isOpen: boolean;
  id: string;
  orderAction:OrderAction
  createdOnUtc: Date;
  lastModifiedOnUtc: Date;
}

enum OrderAction {
  buy,
  sell

}

interface Tradingtarget {
  epic: string;
  name: string;
  chartCode: string;
  currencyCode: string;
  status: number;
  profit: number;
  riskPercent: number;
  targetPercent: number;
  orders?: Order[];
  initialDeposit: number;
  expiry: string;
  scalingFactor: number;
  marginDepositBands?: any;
  movingAverageLength: number;
  tradingLevel: number;
  id: string;
  createdOnUtc: Date;
  lastModifiedOnUtc: Date;
  showOrders: boolean;
}

interface OrdersDetail {
  winLossRate: number | null;
  totalProfit: number | null;
  tradeCount: number | null;
  minDeposit: number | null;
  maxDeposit: number | null;
  totalProfitTrend: trend;
}

enum trend {
  Up = 0,
  Down = 1,
  Minus = 2
}

export interface TradingtargetNames {
  [key: string]: string;
}
