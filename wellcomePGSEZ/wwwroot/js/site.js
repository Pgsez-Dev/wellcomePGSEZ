

//window.addEventListener('scroll', () => {
//    const headingContainer = document.querySelector('.heading_container');
//    const container = document.querySelector('.container.shadow-g');
//    const maxScroll = 180; // حداکثر مقداری که می‌خواهید محو شدن کامل شود
//    const currentScroll = window.scrollY;

//    // محاسبه مقدار opacity بر اساس میزان اسکرول
//    let opacity = 1 - (currentScroll / maxScroll);
//    if (opacity < 0) opacity = 0;

//    // محاسبه مقدار transform بر اساس میزان اسکرول
//    let translateY = (currentScroll / maxScroll) * -50; // جابجایی به بالا
//    let translateZ = (currentScroll / maxScroll) * -100; // جابجایی به عقب
//    if (translateY < -50) translateY = -50;
//    if (translateZ < -30) translateZ = -30;

//    headingContainer.style.opacity = opacity;
//    headingContainer.style.transform = `translateY(${translateY}px) translateZ(${translateZ}px)`;

//    // تنظیم position برای container
//    let containerTop = currentScroll / maxScroll * 100; // تنظیم مقدار بر حسب نیاز
//    if (containerTop > -50) containerTop = -50;
//    container.style.top = `${containerTop}px`;
//});

;

//const themeSwitch = document.getElementById('themeSwitch');
//themeSwitch.addEventListener('change', () => {
//    document.body.classList.toggle('dark-mode');
//    document.body.classList.toggle('light-mode');

//    // تغییر متن بر اساس حالت روشن/تاریک
//    const modeText = document.querySelector('.mode-text');
//    if (themeSwitch.checked) {
//        modeText.textContent = 'تاریک';
//    } else {
//        modeText.textContent = 'روشن';
//    }
//});





