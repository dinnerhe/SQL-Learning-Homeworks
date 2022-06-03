
console.log("Hello World!");
//Question 1
let salaries = {John: 100,Ann: 160,Pete: 130};
let sum = 0
for (let item in salaries){
    sum += salaries[item];
    //console.log(item);
}
console.log(sum);

//Question 2
let menu = {width: 200,height: 300,title: "My menu"};
function multiplyNumeric(obj){
    for (let item in obj){
        if(typeof(obj[item]) === "number"){
            obj[item] *=2;
        }
    }
}

multiplyNumeric(menu);
console.log(menu)

//Question 3
function checkEmailId(str){
    let re = /.*@.+\..*/
    return str.match(re) != null
}
console.log(checkEmailId("123@156.edu"))
console.log(checkEmailId("123.edu@133"))

//Question 4
function truncate(str, len){
    if(str.length <= len) return str;
    else return str.slice(0, len) + "..."
}

console.log(truncate("What I'd like to tell on this topic is:", 20));
console.log(truncate("Hi everyone!", 20));

//Question 5
let arr = ["James", "Brennie"];
arr.push("Robert");
console.log(arr);
arr[(arr.length- arr.length%2)/2 ] = "Calvin";
console.log(arr);
console.log(arr.shift());
console.log(arr);
arr.unshift("Rose");
arr.unshift("Regal");
console.log(arr);
