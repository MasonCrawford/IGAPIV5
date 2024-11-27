import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {newArray} from "@angular/compiler/src/util";

@Component({
  selector: 'app-Logs',
  templateUrl: './Logs.component.html',
  styleUrls: ['./Logs.component.css']
})
export class LogsComponent implements OnInit {

  public pagedReponse:PagedReponse = new class implements PagedReponse {
    data: Logs[] | null = null;
    errors: any = null;
    firstPage: string | null = null;
    lastPage: string | null = null;
    message: any = null;
    nextPage: string | null = null;
    pageNumber: number | null = null;
    pageSize: number | null = null;
    previousPage: any = null;
    succeeded: boolean | null = null;
    totalPages: number | null = null;
    totalRecords: number | null = null;
  }
  public logs: Logs[] = [];
  public categories: string[] = [];
  public webjobDetails : WebjobDetails | null = null;
  constructor(readonly http: HttpClient, @Inject('BASE_URL') readonly baseUrl: string) {
    this.http.get<PagedReponse>(this.baseUrl + 'api/logs/').subscribe(result => {
      this.pagedReponse = result;
      if (this.pagedReponse.data) this.logs = this.pagedReponse.data;
    }, error => console.error(error));

    this.http.get<WebjobDetails>('https://ig-api.scm.azurewebsites.net/api/triggeredwebjobs/IG-API',).subscribe(result => {
      this.webjobDetails = result;
      if (this.pagedReponse.data) this.logs = this.pagedReponse.data;
    }, error => console.error(error));
  }

  public getCategories() {
    this.http.get<string[]>(this.baseUrl + 'api/logs/categories').subscribe(result => {
      this.categories = result;
    }, error => console.error(error));

  }

  public getLogs(logLevel: string) {
    this.http.get<PagedReponse>(this.baseUrl + 'api/logs/' + logLevel).subscribe(result => {
      this.pagedReponse = result;
      if (this.pagedReponse.data) this.logs = this.pagedReponse.data;
    }, error => console.error(error));
  }

  public getNext(){
    if (this.pagedReponse.nextPage)
      this.http.get<PagedReponse>(this.pagedReponse.nextPage).subscribe(result => {
        this.pagedReponse = result;
        if (this.pagedReponse.data) this.logs = this.pagedReponse.data;
      }, error => console.error(error));
  }

  public getPrev(){
    this.http.get<PagedReponse>(this.pagedReponse.previousPage).subscribe(result => {
      this.pagedReponse = result;
      if (this.pagedReponse.data) this.logs = this.pagedReponse.data;
    }, error => console.error(error));
  }

  public getPage(page:number|null){
    this.http.get<PagedReponse>(this.baseUrl + 'api/logs?pageNumber='+page+'&pageSize=50').subscribe(result => {
      this.pagedReponse = result;
      if (this.pagedReponse.data) this.logs = this.pagedReponse.data;
    }, error => console.error(error));
  }


  createRange(){
    if (this.pagedReponse.totalPages && this.pagedReponse.pageNumber){
      var pages:number[]=[];
      if (this.pagedReponse.totalPages > 10) {
        if (this.pagedReponse.pageNumber <= 6){
          for (let i = 2; i <= 10; i++) {
            pages.push(i);
          }
        }else if(this.pagedReponse.pageNumber >= this.pagedReponse.totalPages-6){
          for (let i = this.pagedReponse.totalPages-9; i < this.pagedReponse.totalPages; i++) {
            pages.push(i);
          }
        } else{
          for (let i = this.pagedReponse.pageNumber-4; i <= this.pagedReponse.pageNumber+4; i++) {
            pages.push(i);

          }
        }
      }else {
        for (let i = 2; i <= this.pagedReponse.totalPages-1; i++) {
          pages.push(i);
        }
      }
      return pages;
    }
    return
  }

  ngOnInit(): void {
    this.getCategories();
  }

}

interface Logs {
  logLevel: string | null;
  categoryName: string | null;
  msg: string | null;
  user: string | null;
  timestamp: Date | null;
  id: string | null;
}
export interface PagedReponse {
  pageNumber: number | null;
  pageSize: number | null;
  firstPage: string | null;
  lastPage: string | null;
  totalPages: number | null;
  totalRecords: number | null;
  nextPage: string | null;
  previousPage?: any;
  data: Logs[] | null;
  succeeded: boolean | null;
  errors?: any;
  message?: any;
}



export interface LatestRun {
  id: string;
  name: string;
  status: string;
  start_time: Date;
  end_time: Date;
  duration: string;
  output_url: string;
  error_url?: any;
  url: string;
  job_name: string;
  trigger: string;
}

export interface Settings {
}

export interface WebjobDetails {
  latest_run: LatestRun;
  history_url: string;
  scheduler_logs_url?: any;
  name: string;
  run_command: string;
  url: string;
  extra_info_url: string;
  type: string;
  error?: any;
  using_sdk: boolean;
  settings: Settings;
}
