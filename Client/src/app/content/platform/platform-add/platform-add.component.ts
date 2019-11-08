import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Response } from '../../../Models/response';

import { PlatformService } from '../../../Services/platform.service';

import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';


@Component({
  selector: 'app-platform-add',
  templateUrl: './platform-add.component.html',
  styleUrls: ['./platform-add.component.scss']
})
export class PlatformAddComponent implements OnInit {

  private newPlatform: PlatformAdd;

  // Form
  private submitted = false;
  private addModelForm: FormGroup;

  constructor(private router: Router, private formBuilder: FormBuilder, private platformService: PlatformService) { }

  async ngOnInit() {
    // Create initial form
    this.addModelForm = this.formBuilder.group({
      Name: ['', [Validators.required, Validators.minLength(3)]]
    });
  }
  // getter for easy access to form fields
  get f() { return this.addModelForm.controls; }

  async AddPlatform() {
    // Form was submitted
    this.submitted = true;

    // Check if form is valid
    if(this.addModelForm.invalid) {
      return;
    }

    // Get form information
    this.newPlatform = {
      Name: this.addModelForm.value.Name
    }

    // Create a new platform
    this.platformService.addPlatform(this.newPlatform).then((res: Response<Platform>) => {
      if(res.DidError)
      {
        alert(res.Message);
      }
      else
      {
        this.router.navigate(['/platforms/' + res.Model.PlatformId]);
      }
    });
 }
}
