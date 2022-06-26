import { Injectable, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs";

@Injectable()
export class BaseComponent implements OnDestroy {
  private subscriptions: Subscription[] = [];

  protected addSubscription(...subs: Subscription[]): void {
    this.subscriptions.push(...subs);
  }

  public ngOnDestroy(): void {
    this.subscriptions.forEach((sub: Subscription) => sub.unsubscribe());
  }
}
