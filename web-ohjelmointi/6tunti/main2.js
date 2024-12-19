let [a, b] = [10, 20];
console.log(a);

let loput;
[a, b, ...loput] = [10, 20, 30, 40, 50];
console.log(loput);

const user = { userId: 42, userName: 'testbot' };
const { userId, userName } = user;
console.log("des: ", userId, userName);
console.log("obj: ", user.userId, user.userName);

const hello = (name) => `Hello, ${name}!`;