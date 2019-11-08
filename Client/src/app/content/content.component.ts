import { Component, OnInit } from '@angular/core';

declare const MoveSidebarNav: any;


@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class ContentComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    MoveSidebarNav();
  }

}
