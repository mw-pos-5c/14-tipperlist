import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'goalDiff'
})
export class GoalDiffPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
