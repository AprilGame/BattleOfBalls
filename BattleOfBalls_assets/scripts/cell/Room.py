# -*- coding: utf-8 -*-
import Math
import random
import KBEngine
from KBEDebug import *

MAX_FOOD_NUM=3000
MAX_SMASH_NUM=100
MAX_MAP_SIZE=100
OVER_GAME_TIMER=1
UPDATE_GAME_TIMER=2


class Room(KBEngine.Entity):
	def __init__(self):
		KBEngine.Entity.__init__(self)
		self.position=(999999.0,0.0,0.0)
		KBEngine.addSpaceGeometryMapping(self.spaceID, None, "spaces/GameMap")
		KBEngine.globalData["Room_%i" % self.spaceID] = self
		

		self.foodEntity=[]
		self.smashEntity=[]
		self.playerScore={}


		#定时器：游戏结束
		self.addTimer(480,0,OVER_GAME_TIMER)
		#定时器：添加食物和破碎球
		self.addTimer(1,4,UPDATE_GAME_TIMER)




	#更新食物和破碎球，保持数量平衡
	def updateFoodSmash(self):
		foodCount=len(self.foodEntity)

		if foodCount<MAX_FOOD_NUM:
			for i in range(100):
				dir=(0.0,0.0,0.0)
				pos=self.createPosition3D()
				modelType=random.randint(0,15)
				entity=KBEngine.createEntity("Food",self.spaceID,pos,dir,{"modelType":modelType})
				self.foodEntity.append(entity.id)

		smashCount=len(self.smashEntity)
		if smashCount<MAX_SMASH_NUM:
			for i in range(10):
				dir=(0.0,0.0,0.0)
				pos=self.createPosition3D()
				modelType=random.randint(0,2)
				entity=KBEngine.createEntity("Smash",self.spaceID,pos,dir,{"modelType":modelType})
				self.smashEntity.append(entity.id)


	#食物被吃掉
	def onFoodDestroy(self,foodID):
		if foodID not in self.foodEntity:
			return
		self.foodEntity.remove(foodID)

	#破碎球被撞
	def onSmashDestroy(self,smashID):
		if smashID not in self.smashEntity:
			return
		self.smashEntity.remove(smashID)


	#房间实体销毁回调
	def onDestroy(self):
		del KBEngine.globalData["Room_%i" % self.spaceID]


	#定时器回调
	def onTimer(self,id,userArg):
		if userArg==UPDATE_GAME_TIMER:
			self.updateFoodSmash()

		elif userArg==OVER_GAME_TIMER:
			self.base.onPlayerGameOver()
			self.destroySpace()


	#随机坐标
	def createPosition3D(self):
		return Math.Vector3(random.randint(0, MAX_MAP_SIZE), 0.0, random.randint(0, MAX_MAP_SIZE))


	#生产碎片
	def createFoodShatter(self,mass,x,z):
		num=mass//10
		for i in range(num):
			mass-=10
			posX=random.uniform(0,4)
			posZ=random.uniform(0,4)
			dir=(0.0,0.0,0.0)
			pos=(x+posX,0.0,y+posZ)
			entity=KBEngine.createEntity("Food",self.spaceID,pos,dir,{"foodMass":10,"modelType":16})
			self.foodEntity.append(entity.id)

		if mass>0:
			posX=random.uniform(0,4)
			posZ=random.uniform(0,4)
			dir=(0.0,0.0,0.0)
			pos=(x+posX,0.0,z+posZ)
			entity=KBEngine.createEntity("Food",self.spaceID,pos,dir,{"foodMass":mass,"modelType":16})
			self.foodEntity.append(entity.id)






