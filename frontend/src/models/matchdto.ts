export interface MatchDto {
  id: number;
  dateString: string;
  gruppe: string;
  seq: number;
  shot: number;
  received: number;
  team1Id: number;
  team2Id: number;
  team1Name: string;
  team2Name: string;
}

export const matchDtoDefault: MatchDto = {
  id: -1,
  dateString: '',
  gruppe: 'A',
  seq: 0,
  shot: 0,
  received: 0,
  team1Id: 0,
  team2Id: 0,
  team1Name: '',
  team2Name: '',
};