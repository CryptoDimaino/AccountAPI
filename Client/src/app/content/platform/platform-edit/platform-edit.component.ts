import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { PlatformService } from '../../../Services/platform.service';

import { Response } from '../../../Models/response';
import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';

@Component({
  selector: 'app-platform-edit',
  templateUrl: './platform-edit.component.html',
  styleUrls: ['./platform-edit.component.scss']
})
export class PlatformEditComponent implements OnInit {

  // Route Id
  private id: number;
  private loaded: boolean;

  private Title: string;

  private response: Response<PlatformEdit>
  private platform: PlatformEdit;

  // Form
  private submitted = false;
  private editModelForm: FormGroup;

  constructor(private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder, private platformService: PlatformService, private datePipe: DatePipe) { }

  async ngOnInit() {
    this.loaded = false;
    this.id = this.route.snapshot.params.id;
    this.Title = "Editing...";

    this.editModelForm = this.formBuilder.group({
      Name: ['', [Validators.required, Validators.minLength(3)]],
      URLToDocumentation:  ['']
    });

    await this.loadResponse();

    // Checks to see if there was an error trying to load the API
    if(this.response.DidError) {
      // Title
      this.Title = "Error";
    }
    else {
      this.Title = `${this.platform.Name} Platform`;

      this.editModelForm = this.formBuilder.group({
        Name: [this.platform.Name, [Validators.required, Validators.minLength(3)]],
        URLToDocumentation:  [this.platform.URLToDocumentation]
      });
    }
  }

  async loadResponse() {
    await this.platformService.getPlatform(this.id).then((data: Response<PlatformEdit>) => {
      this.response = data;
      this.platform = data.Model;
      this.loaded = true;
    });
  }

  get f() { return this.editModelForm.controls; }

  async onEdit() {
    this.submitted = true;

    if(this.editModelForm.invalid) {
      return;
    }

    this.platform = {
      PlatformId: this.id,
      Name: this.editModelForm.value.Name,
      URLToDocumentation: this.editModelForm.value.URLToDocumentation
    };

    await this.platformService.editPlatform(this.platform).then((data: Response<Platform>) => {
      if(data.DidError) {
        alert(data.Message);
      }
      else {
        this.router.navigate(['/platforms/' + this.id]);
      }
    });
  }
}
