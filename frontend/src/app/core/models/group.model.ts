export interface Group {
  id: string;
  name: string;
  information?: string;
  currency: string;
  currencyCode?: string;
  createdAt: Date;
}

export interface CreateGroup {
  name: string;
  information?: string;
  currency: string;
  currencyCode?: string;
}

export interface UpdateGroup {
  name: string;
  information?: string;
  currency: string;
  currencyCode?: string;
}
