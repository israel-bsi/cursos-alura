function alterarStatus(id) {
    let clickedGame = document.getElementById(`game-${id}`);
    let image = clickedGame.querySelector('.dashboard__item__img');
    let button = clickedGame.querySelector('.dashboard__item__button');

    
    
    if (botao.classList.contains('dashboard__item__img--rented') && botao.classList.contains('dashboard__item__button--return')) {
        botao.classList.remove('dashboard__item__button--return');
        botao.classList.remove('dashboard__item__img--rented');
    }
    else {
        botao.classList.add('dashboard__item__button--return');
        botao.classList.add('dashboard__item__img--rented');
    }
}