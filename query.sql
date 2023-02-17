select P.Name, C.Name
from Products as P
         left join CategoryProduct CP on P.Id = CP.ProductsId
         left join Categories C on C.Id = CP.CategoriesId;