export interface EventList {
  Id: number;
  Name: string;
  Location: string;
  StartDate: Date;
  EndDate: Date;
  AccountCount: number;
  GameCount: number;
}

export interface EventAdd {
  Name: string;
  Location: string;
  StartDate: Date;
  EndDate: Date;
}

export interface EventEdit {
  EventId: number;
  Name: string;
  Location: string;
  StartDate: Date;
  EndDate: Date;
  UpdatedAt: Date;
}

export interface Event {
  EventId: number;
  Name: string;
  Location: string;
  StartDate: Date;
  EndDate: Date;
  CreatedAt: Date;
  UpdatedAt: Date;
  Accounts: EventAccounts[];
  Games: EventGames[];
}

export interface EventAccounts {
  AccountId: number;
  Username: string;
  Password: string;
  EmailAccountId: number;
  Email: string;
  EmailPassword: string;
}

export interface EventGames {
  GameId: number;
  GameTitle: string;
  PlatformId: number;
  PlatformName: string;
  URLToDocumentation: string;
}