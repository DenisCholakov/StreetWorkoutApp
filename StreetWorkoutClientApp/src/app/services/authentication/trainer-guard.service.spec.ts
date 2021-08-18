import { TestBed } from '@angular/core/testing';

import { TrainerGuardService } from './trainer-guard.service';

describe('TrainerGuardService', () => {
  let service: TrainerGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrainerGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
