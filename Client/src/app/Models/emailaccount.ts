export interface EmailAccountList {
  Id: number;
  Email: string;
  Password: string;
}

export interface EmailAccountAdd {
  Email: string;
  EmailPassword: string;
}

export interface EmailAccountEdit {
  EmailAccountId: number;
  Email: string;
  EmailPassword: string;
  UpdatedAt: Date;
}

export interface EmailAccount {
  EmailAccountId: number;
  Email: string;
  EmailPassword: string;
  CreatedAt: Date;
  UpdatedAt: Date;
  Accounts: EmailAccountAccounts[];
}

export interface EmailAccountAccounts {
  AccountId: number;
  Username: string;
  UserPassword: string;
}