export enum SplitMode {
  Evenly = 0,
  ByShares = 1,
  ByPercentage = 2,
  ByAmount = 3
}

export interface Expense {
  id: string;
  groupId: string;
  expenseDate: Date;
  title: string;
  categoryId: number;
  amount: number;
  paidById: string;
  isReimbursement: boolean;
  splitMode: SplitMode;
  notes?: string;
  createdAt: Date;
}

export interface CreateExpense {
  groupId: string;
  expenseDate: Date;
  title: string;
  categoryId: number;
  amount: number;
  paidById: string;
  isReimbursement: boolean;
  splitMode: SplitMode;
  notes?: string;
  paidFor: ExpensePaidFor[];
}

export interface UpdateExpense {
  expenseDate: Date;
  title: string;
  categoryId: number;
  amount: number;
  paidById: string;
  isReimbursement: boolean;
  splitMode: SplitMode;
  notes?: string;
  paidFor: ExpensePaidFor[];
}

export interface ExpensePaidFor {
  participantId: string;
  shares: number;
}
