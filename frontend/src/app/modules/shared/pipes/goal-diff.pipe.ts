import { Pipe, PipeTransform } from '@angular/core';
import {SingleTippDto} from "../../../../models/singletippdto";

@Pipe({
  name: 'goalDiff'
})
export class GoalDiffPipe implements PipeTransform {

  transform(value: SingleTippDto[], ...args: number[]): SingleTippDto[] {
    return value.filter(x => Math.abs(x.received-x.shot) > args[0] || 0);
  }

}
