const $ = document.querySelector.bind(document)
const $$ = document.querySelectorAll.bind(document)
let products = [{
        name: 'Vintas Mister NE - High Top',
        image1: './Image/Shoes-Ananas/ananas-1',
        image2: './Image/Shoes-Ananas/ananas-1.2',
        image3: './Image/Shoes-Ananas/ananas-1.3',
        image4: './Image/Shoes-Ananas/ananas-1.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'Urbas Retrospective - Mid Top',
        image1: './Image/Shoes-Ananas/ananas-2.1',
        image2: './Image/Shoes-Ananas/ananas-2.2',
        image3: './Image/Shoes-Ananas/ananas-2.3',
        image4: './Image/Shoes-Ananas/ananas-2.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'Urbas Retrospective - Mid Top',
        image1: './Image/Shoes-Ananas/ananas-3.1',
        image2: './Image/Shoes-Ananas/ananas-3.2',
        image3: './Image/Shoes-Ananas/ananas-3.3',
        image4: './Image/Shoes-Ananas/ananas-3.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'Urbas Retrospective - Low Top',
        image1: './Image/Shoes-Ananas/ananas-4.1',
        image2: './Image/Shoes-Ananas/ananas-4.2',
        image3: './Image/Shoes-Ananas/ananas-4.3',
        image4: './Image/Shoes-Ananas/ananas-4.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'Urbas Retrospective - Low Top',
        image1: './Image/Shoes-Ananas/ananas-5.1',
        image2: './Image/Shoes-Ananas/ananas-5.2',
        image3: './Image/Shoes-Ananas/ananas-5.3',
        image4: './Image/Shoes-Ananas/ananas-5.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'Urbas Retrospective - Low Top',
        image1: './Image/Shoes-Ananas/ananas-6.1',
        image2: './Image/Shoes-Ananas/ananas-6.2',
        image3: './Image/Shoes-Ananas/ananas-6.3',
        image4: './Image/Shoes-Ananas/ananas-6.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'Basas Bumper Gum NE - Mule',
        image1: './Image/Shoes-Ananas/ananas-7.1',
        image2: './Image/Shoes-Ananas/ananas-7.2',
        image3: './Image/Shoes-Ananas/ananas-7.3',
        image4: './Image/Shoes-Ananas/ananas-7.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'Basas Bumper Gum NE - Mule',
        image1: './Image/Shoes-Ananas/ananas-8.1',
        image2: './Image/Shoes-Ananas/ananas-8.2',
        image3: './Image/Shoes-Ananas/ananas-8.3',
        image4: './Image/Shoes-Ananas/ananas-8.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'Basas Bumper Gum NE - Mule',
        image1: './Image/Shoes-Ananas/ananas-9.1',
        image2: './Image/Shoes-Ananas/ananas-9.2',
        image3: './Image/Shoes-Ananas/ananas-9.3',
        image4: './Image/Shoes-Ananas/ananas-9.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'UA Project Rock',
        image1: './Image/Shoes-Ananas/ananas-1',
        image2: './Image/Shoes-Ananas/ananas-1.2',
        image3: './Image/Shoes-Ananas/ananas-1.3',
        image4: './Image/Shoes-Ananas/ananas-1.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'UA Project Rock',
        image1: './Image/Shoes-Ananas/ananas-1',
        image2: './Image/Shoes-Ananas/ananas-1.2',
        image3: './Image/Shoes-Ananas/ananas-1.3',
        image4: './Image/Shoes-Ananas/ananas-1.4',
        old_price: '400',
        curr_price: '300'
    },
    {
        name: 'UA Project Rock',
        image1: './Image/Shoes-Ananas/ananas-1',
        image2: './Image/Shoes-Ananas/ananas-1.2',
        image3: './Image/Shoes-Ananas/ananas-1.3',
        image4: './Image/Shoes-Ananas/ananas-1.4',
        old_price: '400',
        curr_price: '300'
    },
]
let imgresponsive = $('#img-responsive');
let imga = $('.a');
let imgb = $('.b');
let imgc = $('.c');
let quickview = $('#quick-view-product');
let quickviewclose = $('.quickview-close')
quickviewclose.onclick = function() {
    if (quickview.style.display === 'block') {
        quickview.style.display = 'none';
    }
}

;
document.querySelectorAll('.product-img-item').forEach(e => {
    e.addEventListener('click', () => {
        let img = e.querySelector('img').getAttribute('src')
        document.querySelector('#product-img > img').setAttribute('src', img)
    })
})
const product_card_name = $('.product-card-name');
let product_list = $('#products')
const prod = products.map((product) => {
    return `
    <div class="col-4 ">
                <div class="product-card">
                    <div class="product-card-img">
                        <img src="${product.image1}" alt="">
                        <img src="${product.image2}" alt="">
                        
                    </div>
                    <div class="product-card-info">
                        <div class="product-btn">
                            <a href="./product-detail.html" class="btn-flat btn-hover btn-shop-now">shop now</a>
                            <button class="btn-flat btn-hover btn-cart-add">
                                <i class='bx bxs-cart-add'></i>
                            </button>
                            <button class="btn-flat btn-hover btn-cart-add">
                                <i class='bx bxs-heart'></i>
                            </button>
                        </div>
                        <div class="product-card-name">
                            ${product.name}
                        </div>
                        <div class="product-card-price">
                            <span><del>${product.old_price}</del></span>
                            <span class="curr-price">${product.curr_price}</span>
                        </div>
                    </div>
                </div>
            </div>
    `
})

//product_list.innerHTML = prod.join('')
//const web = {
//    currentIndex: 0,
//    render: function() {
//        const htmls = products.map((e, index) => {
//            return `
//        <div class="quickview-overlay fancybox-overlay fancybox-overlay-fixed" data-index="${index}"></div>
//            <div class="quick-view-product">
//                <div class="block-quickview primary_block row">
//                    <div class="product-left-column col-xs-12 col-sm-4 col-md-4">
//                        <div class="clearfix image-block">
//                            <span class="view_full_size">
//                                <a class="img-product" id="product-img" title="Aeneanin consequated sagittis lacini" href="#">
//                                    <img id="product-featured-image-quickview" class="img-responsive product-featured-image-quickview" src="${e.image1}" alt="Aeneanin consequated sagittis lacini">
//                                </a>
//                            </span>
//                            <div class="loading-imgquickview" style="display:none;"></div>
//                        </div>
//                        <div class="box">
//                            <div class="product-img-list">
//                                <div class="product-img-item a">
//                                    <img src="${e.image2}">
//                                </div>
//                                <div class="product-img-item b">
//                                    <img src="${e.image3}">
//                                </div>
//                                <div class="product-img-item c">
//                                    <img src="${e.image4}">
//                                </div>
//                            </div>
//                        </div>
                        
//                    </div>
//                    <div class="product-center-column product-info col-xs-12 col-sm-4 col-md-5">
//                        <h3 class="qwp-name">Aeneanin consequated sagittis lacini</h3>
//                        <div class="product-description rte">
//                            Note:the size is Asian size, run smaller than US size,please check the size chart before you place order.We recommend one size larger to buy The Classic jersey is the...
//                        </div>
//                        <h5 class="brand">
//                            <span>Vendor:</span> Apollotheme
//                        </h5>
//                        <div class="availability">
//                            <p class="available instock">In Stock</p>
//                        </div>
//                        <div class="product-sku">
//                            <p>
//                                Sku:
//                                <span>36-demo</span>
//                            </p>
//                        </div>
//                        <div class="socialsharing_product no-print">
//                            <ul class="social-sharing list-unstyled">
//                                <li>
//                                    <a class="btn social-sharing btn-facebook" href="#">
//                                        <i class="fa fa--facebook"></i> Facebook
//                                    </a>
//                                </li>
//                                <li>
//                                    <a class="btn social-sharing btn-twitter" href="#">
//                                        <i class="fa fa--facebook"></i> Tweet

//                                    </a>
//                                </li>
//                                <li>
//                                    <a class="btn social-sharing btn-google-plus" href="#">
//                                        <i class="fa fa--facebook"></i> Google+

//                                    </a>
//                                </li>
//                                <li>
//                                    <a class="btn social-sharing btn-pinterest" href="#">
//                                        <i class="fa fa--facebook"></i> Pinterest

//                                    </a>
//                                </li>
//                            </ul>
//                        </div>
//                    </div>
//                    <div class="product-right-column product-item col-xs-12 col-sm-4 col-md-3" id="product-3635844932">
//                        <div>
//                            <form>
//                                <span class="prices">
//                                    <span class="price h2">
//                                        <span class="money">$41.93</span>
//                                </span>
//                                </span>
//                                <span class="price-product-detail">
//                                    <span class="old-price product-price compare-price"></span>
//                                </span>
//                                <div class="clearfix"></div>
//                                <div class="quantity_wanted_p">
//                                    <label for="quantity-detail" class="quantity-selector">Quantity</label>
//                                    <div class="js-qty">
//                                        <button type="button" class="js-qty__adjust js-qty__adjust--minus">-</button>
//                                        <input type="text" class="js-qty__num" value="1" min="1" id="quantity-detail">
//                                        <button type="button" class="js-qty__adjust js-qty__adjust--plus">+</button>
//                                    </div>
//                                </div>
//                                <div class="total-price">
//                                    <label>Subtotal :</label>
//                                    <span>
//                                        <span class="money">${e.curr_price} </span>
//                                    </span>
//                                </div>
//                                <button type="submit" class="btn add_to_cart_detail">
//                                    <span>Add to cart </span>
//                                </button>
//                            </form>
//                        </div>
//                    </div>

//                </div>
//                <a title="Close" class="quickview-close fancybox-close" href="#"></a>
//            </div>
//        `
//        })
//        product_list.innerHTML = htmls.join('');

//    },
//    handleEvents: function() {
//        const _this = this;
//        const shosenode = e.target.closest(('product-card-img'))

//        product_card_name.onclick = function() {
//            if (shosenode) {
//                this.currentIndex = Number(shosenode.dataset.index)
//                this.loadCurrent();
//                this.render();
//            }

//        }

//    },
//    defineProperties: function() {
//        Object.defineProperty(this, 'currentshoes', {
//            get: function() {
//                return this.products[this.currentIndex];
//            }
//        })
//    },
//    start: function() {
//        this.defineProperties();
//        this.loadCurrent();
//        this.handleEvents();
//    },

//    loadCurrent: function() {
//        imgresponsive.src = this.currentshoes.image1;
//        imga.src = this.currentshoes.image2;
//        imgb.src = this.currentshoes.image3;
//        imgc.src = this.currentshoes.image4;
//    }

//}


//web.start();