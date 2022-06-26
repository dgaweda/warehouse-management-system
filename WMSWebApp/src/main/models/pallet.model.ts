import {ErrorMessage} from "../shared/models/error.message.model";

export interface Pallet extends ErrorMessage  {
  id: number;
  palletStatus: string;
  barcode: string;
  orderBarcode: string;
  departureName: string;
  deliveryName: string;
  userFirstName: string;
  userLastName: string;
  products: object[];
}
