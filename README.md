# Winnings group test 

As of right now all the requirements have been implented and we can run the app with IIS Express or with Docker. Having issues with running with Kubernetes. Unable to access the service apis. 

There are 4 APIs that are a part of this solution - 

1. To get all the products without any filters.
      - Route : /api/products
      - Example : https://localhost:49153/api/products
      
2. To get the products based on minimum and maximum price. 
      - Route : /api/products/price/{minimum}/{maximum}
      - Example : https://localhost:49153/api/products/price/100.10/200.20

3. To get the products based on Fantastic attribute.
      - Route : /api/products/fantastic/{isFantastic}
      - Example : https://localhost:49153/api/products/fantastic/true
 
4. To get the products based on minimum and maximum rating
      - Route : /api/products/rating/{minimum}/{maximum}
      - Example : https://localhost:49153/api/products/rating/1.2/2.6

Kubernetes running pods - 
![image](https://user-images.githubusercontent.com/23556964/130810491-3fba4bf3-91d0-4dde-8a85-2543aec2cf70.png)

