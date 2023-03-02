import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ApiserviceService } from 'src/app/apiservice.service';

@Component({
  selector: 'app-show-system',
  templateUrl: './show-system.component.html',
  styleUrls: ['./show-system.component.css']
})
export class ShowSystemComponent implements OnInit {
  SystemList: any = [];
  ModalTitle = "";
  ActivateAddEditSystemComp: boolean = false;
  depart: any;

  SystemIdFilter = "";
  SystemNameFilter = "";
  SystemListWithoutFilter: any = [];
  @ViewChild('closebutton') closebutton?: ElementRef;

  ngOnInit(): void {

    this.refreshDepList();
  }
  callback(value: string) {
    console.log("callback called");
    if (this.closebutton !== undefined) {
      this.closebutton.nativeElement.click();
      this.refreshDepList();
    } else {
      console.log("closebutton undefined");
    }

  }
  refreshDepList() {
    this.service.getSystemList().subscribe(data => {
      this.SystemList = data;
      this.SystemListWithoutFilter = data;
    });
  }
  sortResult(prop: any, asc: any) {
    this.SystemList = this.SystemListWithoutFilter.sort(function (a: any, b: any) {
      if (asc) {
        return (a[prop] > b[prop]) ? 1 : ((a[prop] < b[prop]) ? -1 : 0);
      }
      else {
        return (b[prop] > a[prop]) ? 1 : ((b[prop] < a[prop]) ? -1 : 0);
      }
    });
  }
  FilterFn() {
    var SystemIdFilter = this.SystemIdFilter;
    var SystemNameFilter = this.SystemNameFilter;

    this.SystemList = this.SystemListWithoutFilter.filter(
      function (el: any) {
        return el.id.toString().toLowerCase().includes(
          SystemIdFilter.toString().trim().toLowerCase()
        ) &&
          el.name.toString().toLowerCase().includes(
            SystemNameFilter.toString().trim().toLowerCase())
      }
    );
  }
  addClick() {
    this.depart = {
      Id: "",
      Name: ""
    }
    this.ModalTitle = "システム追加";
    this.ActivateAddEditSystemComp = true;
  }
  editClick(item: any) {
    this.depart = item;
    this.ModalTitle = "システム編集";
    this.ActivateAddEditSystemComp = true;
  }
  deleteClick(item: any) {
    if (confirm('削除しますか?')) {
      this.service.deleteSystem(item.Id).subscribe(data => {
        this.refreshDepList();
      })
    }
  }


  closeClick() {
    this.ActivateAddEditSystemComp = false;
    this.refreshDepList();
  }


  constructor(private service: ApiserviceService) { }
}
