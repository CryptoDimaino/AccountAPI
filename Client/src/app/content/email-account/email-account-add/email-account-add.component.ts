import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Response } from '../../../Models/response';

import { EmailAccountService } from '../../../Services/email-account.service';

import { EmailAccountList, EmailAccountAdd, EmailAccountEdit, EmailAccount } from '../../../Models/emailaccount';


@Component({
  selector: 'app-email-account-add',
  templateUrl: './email-account-add.component.html',
  styleUrls: ['./email-account-add.component.scss']
})
export class EmailAccountAddComponent implements OnInit {

  // Loaded
  // private loaded = false;

  // Models
  private newEmailAccount: EmailAccountAdd;

  // Form
  private submitted = false;
  private addModelForm: FormGroup;

  constructor(private router: Router, private formBuilder: FormBuilder, private emailaccountService: EmailAccountService) { }

  async ngOnInit() {
    // Check if API was loaded
    // this.loaded = false;

    // Create initial form
    this.addModelForm = this.formBuilder.group({
      Email: ['', [Validators.required, Validators.minLength(10)]],
      EmailPassword: ['', [Validators.required, Validators.minLength(5)]]
    });
  }

  // getter for easy access to form fields
  get f() { return this.addModelForm.controls; }

  AddEmailAccount() {
    // Form was submitted
    this.submitted = true;

    // Check if form is valid
    if(this.addModelForm.invalid) {
      return;
    }

    // Get form information
    this.newEmailAccount = {
      Email: this.addModelForm.value.Email,
      EmailPassword: this.addModelForm.value.EmailPassword
    }

    // Create a new email account
    this.emailaccountService.addEmailAccount(this.newEmailAccount).then((response: Response<EmailAccount>) => {
      if(response.DidError)
      {
        alert(response.Message);
      }
      else
      {
        this.router.navigate(['/emailaccount/' + response.Model.EmailAccountId]);
      }
    });
 }
}
