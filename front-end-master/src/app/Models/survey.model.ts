import {AbstractControl} from "@angular/forms";

export interface Survey{
  IDTopic?: number,
  name?: string,
  description?: string,
  opening_Time?: Date,
  closing_Time?: Date,
  created_By?: string,
  modified_By?: string

}
