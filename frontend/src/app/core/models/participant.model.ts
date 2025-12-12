export interface Participant {
  id: string;
  name: string;
  groupId: string;
  createdAt: Date;
}

export interface CreateParticipant {
  name: string;
  groupId: string;
}

export interface UpdateParticipant {
  name: string;
}
