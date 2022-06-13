const $ = document.querySelector.bind(document)
const $$ = document.querySelectorAll.bind(document)
let products = [{
        name: 'Aeneanin consequated sagittis lacini',
        image: './Image/image3.png',
        price: '400'

    },
    {
        name: 'Aeneanin consequated sagittis lacini',
        image: './Image/image3.png',
        price: '400'

    },
    {
        name: 'Aeneanin consequated sagittis lacini',
        image: './Image/image3.png',
        price: '400'

    },


]
let product_list = $('.owl-item')

const prod = products.map((product) => {
    return `  
    
    <div class="item" style="width: 380px;">
    <div class="class-product   ">

        <div class="left-block">
            <div class="product-image-content">
                <a class="product-img-link" href="#"></a>
                <img class="img-product" src="${product.image}">
            </div>
        </div>
        <div class="right-block">
            <div class="product-meta">
                <h5 class="name">
                    <a class="product-name" href="#">
                    ${product.name}
                    </a>
                </h5>
                <div class="review-star">
                    <i class="fa-solid fa-star icon-star"></i>
                    <i class="fa-solid fa-star icon-star"></i>
                    <i class="fa-solid fa-star icon-star"></i>
                    <i class="fa-solid fa-star icon-star"></i>
                    <i class="fa-solid fa-star icon-star"></i>
                </div>
                <div class="content-price">
                    <span class="money">${product.price}</span>
                </div>
                <div class="function">
                    <div class="arrow">
                        <a class="arrow-link icon-function" href="#">
                            <i class="fa-solid fa-arrows-to-circle colorheart"></i>
                        </a>
                    </div>
                    <div class="wish-list icon-function">
                        <a class="wish-list-link" href="#">
                            <i class="fa-solid fa-heart colorheart"></i>
                        </a>
                    </div>
                    <form>
                        <a class="btnrounded icon-function" href="#">
                            <i class="fa-solid fa-cart-arrow-down colorheart "></i>

                        </a>
                    </form>
                </div>
            </div>
        </div>

    </div>

    <div class="class-product ">
        <div class="left-block">
            <div class="product-image-content">
                <a class="product-img-link" href="#"></a>
                <img class="img-product" src="${product.image}">
            </div>
        </div>
        <div class="right-block">
            <div class="product-meta">
                <h5 class="name">
                    <a class="product-name" href="#">
                    ${product.name}
                    </a>
                </h5>
                <div class="review-star">
                    <i class="fa-solid fa-star icon-star"></i>
                    <i class="fa-solid fa-star icon-star"></i>
                    <i class="fa-solid fa-star icon-star"></i>
                    <i class="fa-solid fa-star icon-star"></i>
                    <i class="fa-solid fa-star icon-star"></i>
                </div>
                <div class="content-price">
                    <span class="money">${product.price}</span>
                </div>
                <div class="function">
                    <div class="arrow">
                        <a class="arrow-link icon-function" href="#">
                            <i class="fa-solid fa-arrows-to-circle colorheart"></i>
                        </a>
                    </div>
                    <div class="wish-list icon-function">
                        <a class="wish-list-link" href="#">
                            <i class="fa-solid fa-heart colorheart"></i>
                        </a>
                    </div>
                    <form>
                        <a class="btnrounded icon-function" href="#">
                            <i class="fa-solid fa-cart-arrow-down colorheart "></i>

                        </a>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>`


})
product_list.innerHTML = prod.join('')



console.log(222)