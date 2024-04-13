-- Castlevania: Symphony of the Night PSX autosplitter for LiveSplit made by TalicZealot
-- Base code by Trysdyn Black
-- Requires LiveSplit 1.7+

local splits = {
    ["SecondCastle"] = { on = true, split = false },

    ["Shaft"] = { on = false, split = false },
    ["Dracula"] = { on = true, split = false },

    ["SoulOfBat"] = { on = true, split = false, relic = true },
    ["FireOfBat"] = { on = false, split = false, relic = true },
    ["EchoOfBat"] =  { on = false, split = false, relic = true },
    ["ForceOfEcho"] = { on = false, split = false, relic = true },
    ["SoulOfWolf"] = { on = false, split = false, relic = true },
    ["PowerOfWolf"] = { on = false, split = false, relic = true },
    ["SkillOfWolf"] = { on = false, split = false, relic = true },
    ["FormOfMist"] = { on = true, split = false, relic = true },
    ["PowerOfMist"] = { on = false, split = false, relic = true },
    ["GasCloud"] = { on = false, split = false, relic = true },
    ["CubeOfZoe"] = { on = false, split = false, relic = true },
    ["SpiritOrb"] = { on = false, split = false, relic = true },
    ["GravityBoots"] = { on = false, split = false, relic = true },
    ["LeapStone"] = { on = false, split = false, relic = true },
    ["HolySymbol"] = { on = false, split = false, relic = true },
    ["FaerieScroll"] = { on = false, split = false, relic = true },
    ["JewelOfOpen"] = { on = false, split = false, relic = true },
    ["MermanStatue"] = { on = false, split = false, relic = true },
    ["BatCard"] = { on = false, split = false, relic = true },
    ["GhostCard"] = { on = false, split = false, relic = true },
    ["FaerieCard"] = { on = false, split = false, relic = true },
    ["DemonCard"] = { on = false, split = false, relic = true },
    ["SwordCard"] = { on = false, split = false, relic = true },
    ["HeartOfVlad"] = { on = false, split = false, relic = true },
    ["ToothOfVlad"] = { on = false, split = false, relic = true },
    ["RibOfVlad"] = { on = false, split = false, relic = true },
    ["RingOfVlad"] = { on = false, split = false, relic = true },
    ["EyeOfVlad"] = { on = false, split = false, relic = true },

    ["GoldRing"] = { on = false, split = false, item = true },
    ["SilverRing"] = { on = false, split = false, item = true },
    ["HolyGlasses"] = { on = false, split = false, item = true },
    ["ShieldRod"] = { on = false, split = false, item = true },

    ["DraculaPrologue"] = { on = false, split = false, boss = true },
    ["Olrox"] = { on = false, split = false, boss = true },
    ["Doppleganger10"] = { on = true, split = false, boss = true },
    ["Granfaloon"] = { on = false, split = false, boss = true },
    ["Scylla"] = { on = false, split = false, boss = true },
    ["SlograGaibon"] = { on = true, split = false, boss = true },	
    ["Hippogryph"] = { on = false, split = false, boss = true },
    ["Beelzebub"] = { on = false, split = false, boss = true },
    ["Karasuman"] = { on = false, split = false, boss = true },
    ["Trio"] = { on = false, split = false, boss = true },
    ["Cerberus"] = { on = false, split = false, boss = true },
    ["Medusa"] = { on = false, split = false, boss = true },
    ["Creature"] = { on = false, split = false, boss = true },
    ["LesserDemon"] = { on = false, split = false, boss = true },
    ["Doppleganger40"] = { on = false, split = false, boss = true },
    ["Akmodan"] = { on = false, split = false, boss = true },
    ["DarkwingBat"] = { on = false, split = false, boss = true },
    ["Galamoth"] = { on = false, split = false, boss = true },

    ["ClockRush"] = {
        on = true,
        split = false,
        location = true,
        from = {
            mapX = {32},
            mapXoffset = {0},
            mapY = {26},
            mapYoffset = {0, 255}
        },
        to = {
            mapX = {32},
            mapXoffset = {0},
            mapY = {24},
            mapYoffset = {1}
        }
    },

    ["OuterWallFromLibrary"] = {
        on = true,
        split = false,
        location = true,
        from = {
            mapX = {59},
            mapXoffset = {1},
            mapY = {21},
            mapYoffset = {0}
        },
        to = {
            mapX = {60},
            mapXoffset = {0},
            mapY = {15},
            mapYoffset = {6}
        }
    },
}
local bosses = {
    ["DraculaPrologue"] = 0x03CA28,
    ["Olrox"] = 0x03CA2C,
    ["Doppleganger10"] = 0x03CA30,
    ["Granfaloon"] = 0x03CA34,
    ["MinotaurWerewolf"] = 0x03CA38,
    ["Scylla"] = 0x03CA3C,
    ["SlograGaibon"] = 0x03CA40,
    ["Hippogryph"] = 0x03CA44,
    ["Beelzebub"] = 0x03CA48,
    ["Succubus"] = 0x03CA4C,
    ["Karasuman"] = 0x03CA50,
    ["Trio"] = 0x03CA54,
    ["Death"] = 0x03CA58,
    ["Cerberus"] = 0x03CA5C,
    ["SaveRichter"] = 0x03CA60,
    ["Medusa"] = 0x03CA64,
    ["Creature"] = 0x03CA68,
    ["LesserDemon"] = 0x03CA6C,
    ["Doppleganger40"] = 0x03CA70,
    ["Akmodan"] = 0x03CA74,
    ["DarkwingBat"] = 0x03CA78,
    ["Galamoth"] = 0x03CA7C,    
    ["FinalSave"] =  0x03CA80,
    ["MeetingDeath"] = 0x03CA84,
    ["GetHolyGlasses"] = 0x03CA88,
    ["MeetLibrarian"] = 0x03CA8C,
    ["MeetMaria"] = 0x03CA90
}
local relics = {
    ["SoulOfBat"] = 0x097964,
    ["FireOfBat"] = 0x097965,
    ["EchoOfBat"] = 0x097966,
    ["ForceOfEcho"] = 0x097967,
    ["SoulOfWolf"] = 0x097968,
    ["PowerOfWolf"] = 0x097969,
    ["SkillOfWolf"] = 0x09796A,
    ["FormOfMist"] = 0x09796B,
    ["PowerOfMist"] = 0x09796C,
    ["GasCloud"] = 0x09796D,
    ["CubeOfZoe"] = 0x09796E,
    ["SpiritOrb"] = 0x09796F,
    ["GravityBoots"] = 0x097970,
    ["LeapStone"] = 0x097971,
    ["HolySymbol"] = 0x097972,
    ["FaerieScroll"] = 0x097973,
    ["JewelOfOpen"] = 0x097974,
    ["MermanStatue"] = 0x097975,
    ["BatCard"] = 0x097976,
    ["GhostCard"] = 0x097977,
    ["FaerieCard"] = 0x097978,
    ["DemonCard"] = 0x097979,
    ["SwordCard"] = 0x09797A,
    ["HeartOfVlad"] = 0x09797D,
    ["ToothOfVlad"] = 0x09797E,
    ["RibOfVlad"] = 0x09797F,
    ["RingOfVlad"] = 0x097980,
    ["EyeOfVlad"] = 0x097981,
}
local items = {
    ["GoldRing"] = 0x097A7B,
    ["SilverRing"] = 0x097A7C,
    ["HolyGlasses"] = 0x097A55,
    ["ShieldRod"] = 0x09798E,
}
local gameAddresses = {
    MapX = 0x0730B0,
    MapXOffset = 0x0973F1,
    MapY = 0x0730B4,
    MapYOffset = 0x0973F5,
    TimeHours = 0x097C30,
    TimeMinutes = 0x097C34,
    TimeSeconds = 0x097C38,
    TimeSubseconds = 0x097C3C,
    GameStatus = 0x03C734,
    SecondCastle = 0x1E5458,
    BossEntityHp = 0x076ed6
}
local location = {
    mapX = {
        current = 0,
        previous = 0
    },
    mapXoffset = {
        current = 0,
        previous = 0
    },
    mapY = {
        current = 0,
        previous = 0
    },
    mapYoffset = {
        current = 0,
        previous = 0
    },
}
local bossHp = {
    current = 0,
    old = 0
}
local started = false


local function init_livesplit()
    pipe_handle = io.open("//./pipe/LiveSplit", 'a')

    if not pipe_handle then
        error("\nFailed to open LiveSplit named pipe!\n" ..
              "Please make sure LiveSplit is running and is at least 1.7, " ..
              "then load this script again")
    end

    pipe_handle:write("reset\r\n")
    pipe_handle:flush()
    print("Connected to LiveSplit")

    return pipe_handle
end

local function RestartSplits()
    for key, val in pairs(splits) do
        splits[key].split = false
        if splits[key].spawned then
            splits[key].spawned = false
        end
    end
end

local function InGame()
    return memory.readbyte(gameAddresses.GameStatus) == 2
end

local function InvertedCastle()
    return memory.readbyte(gameAddresses.SecondCastle) > 0
end

local function InPrologue()
    return (location.mapX.current >= 0 and location.mapX.current <= 1) and (location.mapY.current >= 0 and location.mapY.current <= 2)
end

local function BossDefeated(address)
    return memory.read_s32_le(address) > 0
end

local function RelicCollected(address)
    return memory.readbyte(address) == 3
end

local function ItemCollected(address)
    return memory.readbyte(address) > 0
end

local function LocationReached(split)
    local conditionsMet = false
    for i = 1, #split.from.mapX, 1 do
        if location.mapX.previous == split.from.mapX[i] then
            conditionsMet = true
            break
        end
    end

    if conditionsMet == false then
        return false
    end

    conditionsMet = false
    for i = 1, #split.from.mapXoffset, 1 do
        if location.mapXoffset.previous == split.from.mapXoffset[i] then
            conditionsMet = true
            break
        end
    end

    if conditionsMet == false then
        return false
    end

    conditionsMet = false
    for i = 1, #split.from.mapY, 1 do
        if location.mapY.previous == split.from.mapY[i] then
            conditionsMet = true
            break
        end
    end

    if conditionsMet == false then
        return false
    end

    conditionsMet = false
    for i = 1, #split.from.mapYoffset, 1 do
        if location.mapYoffset.previous == split.from.mapYoffset[i] then
            conditionsMet = true
            break
        end
    end

    if conditionsMet == false then
        return false
    end

    conditionsMet = false
    for i = 1, #split.to.mapX, 1 do
        if location.mapX.current == split.to.mapX[i] then
            conditionsMet = true
            break
        end
    end

    if conditionsMet == false then
        return false
    end

    conditionsMet = false
    for i = 1, #split.to.mapXoffset, 1 do
        if location.mapXoffset.current == split.to.mapXoffset[i] then
            conditionsMet = true
            break
        end
    end

    if conditionsMet == false then
        return false
    end

    conditionsMet = false
    for i = 1, #split.to.mapY, 1 do
        if location.mapY.current == split.to.mapY[i] then
            conditionsMet = true
            break
        end
    end

    if conditionsMet == false then
        return false
    end

    conditionsMet = false
    for i = 1, #split.to.mapYoffset, 1 do
        if location.mapYoffset.current == split.to.mapYoffset[i] then
            conditionsMet = true
            break
        end
    end

    if conditionsMet == false then
        return false
    end

    return true
end

local function BossHp()
    return memory.read_s16_le(gameAddresses.BossEntityHp)
end

local function Start()
    local hours = memory.readbyte(gameAddresses.TimeHours)
    local minutes = memory.readbyte(gameAddresses.TimeMinutes)
    local seconds = memory.readbyte(gameAddresses.TimeSeconds)
    local frames = memory.readbyte(gameAddresses.TimeSubseconds)

    location.mapX.current = memory.readbyte(gameAddresses.MapX)
    location.mapXoffset.current = memory.readbyte(gameAddresses.MapXOffset)
    location.mapY.current = memory.readbyte(gameAddresses.MapY)
    location.mapYoffset.current = memory.readbyte(gameAddresses.MapYOffset)

    if location.mapX.current == 2 and location.mapY.current == 38 and hours == 0 and minutes == 0 and seconds == 0 and frames > 10 then
        started = true
        return true
    elseif hours == 0 and minutes == 0 and seconds == 3 then
        started = true
        return true
    end
end

local function Restart()
    local hours = memory.readbyte(gameAddresses.TimeHours)
    local minutes = memory.readbyte(gameAddresses.TimeMinutes)
    local seconds = memory.readbyte(gameAddresses.TimeSeconds)
    local frames = memory.readbyte(gameAddresses.TimeSubseconds)
    if hours == 0 and minutes == 0 and seconds == 0 and frames < 20 then
        started = false
        return true
    end
end

local function main()

    if InGame() == false then
        return
    end

    if started == false and Start() then
        print("Start")
        pipe_handle:write("starttimer\r\n")
        pipe_handle:flush()
        return
    end

    if started == false then
        return
    end

    if Restart() then
        RestartSplits()
        print("Restart")
        pipe_handle:write("reset\r\n")
        pipe_handle:flush()
        return
    end

    location.mapX.previous = location.mapX.current
    location.mapXoffset.previous = location.mapXoffset.current
    location.mapY.previous = location.mapY.current
    location.mapYoffset.previous = location.mapYoffset.current

    location.mapX.current = memory.readbyte(gameAddresses.MapX)
    location.mapXoffset.current = memory.readbyte(gameAddresses.MapXOffset)
    location.mapY.current = memory.readbyte(gameAddresses.MapY)
    location.mapYoffset.current = memory.readbyte(gameAddresses.MapYOffset)

    bossHp.old = bossHp.current
    bossHp.current = BossHp()

    if InPrologue() then
        return
    end

    for key, val in pairs(splits) do
        if splits[key].on and splits[key].split == false then
            if splits[key].boss and BossDefeated(bosses[key]) then
                print("Split: ".. key)
                pipe_handle:write("split\r\n")
                pipe_handle:flush()
                splits[key].split = true
            elseif splits[key].relic and RelicCollected(relics[key]) then
                print("Split: ".. key)
                pipe_handle:write("split\r\n")
                pipe_handle:flush()
                splits[key].split = true
            elseif splits[key].item and ItemCollected(items[key]) then
                print("Split: ".. key)
                pipe_handle:write("split\r\n")
                pipe_handle:flush()
                splits[key].split = true
            elseif splits[key].location and LocationReached(splits[key]) then
                print("Split: ".. key)
                pipe_handle:write("split\r\n")
                pipe_handle:flush()
                splits[key].split = true 
            end
        end
    end

    if splits["SecondCastle"].on and not splits["SecondCastle"].split then
        if InvertedCastle() then
            print("Split: SecondCastle")
            pipe_handle:write("split\r\n")
            pipe_handle:flush()
            splits["SecondCastle"].split = true
        end
    end

    if splits["Shaft"].on and not splits["Shaft"].split then
        if bossHp.old < 1300 and bossHp.old > 0 and bossHp.current < 1 and (location.mapX.current + location.mapXoffset.current) == 31 and (location.mapY.current + location.mapYoffset.current) == 32 then
            print("Split: Shaft")
            pipe_handle:write("split\r\n")
            pipe_handle:flush()
            splits["Shaft"].split = true
        end
    end

    if splits["Dracula"].on and not splits["Dracula"].split then
        if  bossHp.old < 9999 and bossHp.old > 0 and bossHp.current < 1 and (location.mapX.current + location.mapXoffset.current) == 31 and (location.mapY.current + location.mapYoffset.current) == 30 then
            print("Split: Dracula")
            pipe_handle:write("split\r\n")
            pipe_handle:flush()
            splits["Shaft"].split = true
        end
    end
end

-- Set up our TCP socket to LiveSplit and send a reset to be sure
pipe_handle = init_livesplit()

while true do
    main()
    emu.frameadvance()
end