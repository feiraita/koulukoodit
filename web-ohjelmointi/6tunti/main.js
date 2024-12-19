function product(...luvut) {
    let tulo = 1;
    let count= 0;
    for( let i = luvut.length -1; i >= 0; i--) {
        if(count < 2) {
            tulo *= luvut[1];
            count++;
        }
    }
    return tulo;
}

let numbers = [1, 2, 10];
console.log(product(...numbers));

let obj1 = {foo: 'bar', x: 42};
let obj2 = {foo: 'baz', y: 13};

let cloneObj = {...obj1};
console.log(cloneObj);

let mergedObj = {...obj2, ...obj1};
console.log("lol", mergedObj);