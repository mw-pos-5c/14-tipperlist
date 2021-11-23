import { Pipe, PipeTransform } from '@angular/core';
import {SingleTippDto} from "../../../../models/singletippdto";
import {MatchDto} from "../../../../models/matchdto";

@Pipe({
  name: 'result'
})
export class ResultPipe implements PipeTransform {

  transform(value: SingleTippDto | MatchDto, ...args: unknown[]): string {
    return (value.shot || '0') + ':' + (value.received || '0');
  }

}
