import { MainCategory } from "./MainCategory";
import { SubCategory } from "./SubCategory";

export interface DayWorkResponse {
  日期: string;
  開始時間: string;
  主要分類: MainCategory;
  次要分類: SubCategory;
  備註: string;
  花費時間: 0;
  起始結束: string;
}
