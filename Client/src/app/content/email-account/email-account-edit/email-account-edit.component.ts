import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { EmailAccountService } from '../../../Services/email-account.service';

import { Response } from '../../../Models/response';
import { EmailAccountList, EmailAccountAdd, EmailAccountEdit, EmailAccount } from '../../../Models/emailaccount';


@Component({
  selector: 'app-email-account-edit',
  templateUrl: './email-account-edit.component.html',
  styleUrls: ['./email-account-edit.component.scss']
})
export class EmailAccountEditComponent implements OnInit {

  // Route Id
  private id: number;
  private loaded: boolean;

  private Title: string;

  private response: Response<EmailAccountEdit>
  private emailAccount: EmailAccountEdit;

  // Form
  private submitted = false;
  private editModelForm: FormGroup;

  constructor(private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder, private emailAccountService: EmailAccountService, private datePipe: DatePipe) { }

  async ngOnInit() {
    this.loaded = false;
    this.id = this.route.snapshot.params.id;
    this.Title = "Editing...";

    this.editModelForm = this.formBuilder.group({
      Email: ['', [Validators.required, Validators.minLength(5)]],
      Password:  ['', [Validators.required, Validators.minLength(5)]]
    });

    await this.loadResponse();

    // Checks to see if there was an error trying to load the API
    if(this.response.DidError) {
      // Title
      this.Title = "Error";
    }
    else {
      this.Title = `${this.emailAccount.Email} Email Account`;

      this.editModelForm = this.formBuilder.group({
        Email: [this.emailAccount.Email, [Validators.required, Validators.minLength(5)]],
        Password:  [this.emailAccount.EmailPassword, [Validators.required, Validators.minLength(5)]]
      });
    }
  }

  async loadResponse() {
    await this.emailAccountService.getEmailAccount(this.id).then((data: Response<any>) => {
      this.response = data;
      this.emailAccount = data.Model as EmailAccountEdit;
      this.loaded = true;
      console.log(data);
    });
  }

  get f() { return this.editModelForm.controls; }

  async onEdit() {
    this.submitted = true;

    if(this.editModelForm.invalid) {
      return;
    }

    this.emailAccount = {
      EmailAccountId: this.id,
      Email: this.editModelForm.value.Email,
      EmailPassword: this.editModelForm.value.Password
    }
    console.log(this.emailAccount)
    await this.emailAccountService.editEmailAccount(this.emailAccount).then((data: Response<EmailAccount>) => {
      if(data.DidError) {
        alert(data.Message);
      }
      else {
        this.router.navigate(['/emailaccounts/' + this.id]);
      }
    });
  }
}
